using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerComponent : MonoBehaviour
{
    public static PlayerComponent instance;
    
    public GameObject playerOrientable;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public Transform bulletContainer;
    
    public float playerMoveSpeed;
    public float rotationSpeed;
    public int maxHealth;
    public int currentHealth;
    public bool isInvulnerable;
    public float invulnerabilityTime;
    public int playerDamage;
    public float fireRateTreshold;
    public float dashDuration;
    public float dashDistance;
    public float dashCd;
    public int dashDamage;

    float fireRate;
    float dashCdTime;
    bool canShot;
    bool canDash;
    public bool isDashing;
    bool Shoot1enabled;
    float currentDashTime;
    PlayerInput playerInput;
    Vector3 moveInput;
    Vector3 lookInput;
    Vector3 dashStart;
    Vector3 dashEnd;
    ShipHandler shipHandler;
    [HideInInspector]public PlayerAudio playerAudio;
    MeshTrail meshTrail;
    VFX_Handler vfxHandler;
    Animator animator;

    private void Awake()
    {
        instance = this;
        playerInput = GetComponent<PlayerInput>();
        currentHealth = maxHealth;
        shipHandler = GetComponent<ShipHandler>();
        Input.multiTouchEnabled = false;

        meshTrail = GetComponent<MeshTrail>();
        playerAudio = GetComponent<PlayerAudio>();
        vfxHandler = GetComponent<VFX_Handler>();
        animator = GetComponent<Animator>();
        
    }

    private void Start()
    {
        fireRate = fireRateTreshold;
        shipHandler.SetCore();
        shipHandler.SetFrame(GameManager.instance.shoot1Bool);
        shipHandler.SetWings(GameManager.instance.dashBool);
    }

    private void Update()
    {
        fireRate -= Time.deltaTime;
        dashCdTime -= Time.deltaTime;
        if (dashCdTime<=0)
        {
            canDash = true;
        }
        
        if (fireRate <=0 )
        {
            canShot = true;
        }
        transform.position += playerMoveSpeed * Time.deltaTime * moveInput;
        
        if (lookInput != Vector3.zero)
        {
            Quaternion temp = new Quaternion(0f, Quaternion.LookRotation(lookInput, Vector3.up).y, 0f, Quaternion.LookRotation(lookInput, Vector3.up).w);
            transform.rotation = temp;
        }
        
        if (isDashing)
        {
            canDash = false; //Secure l'input
            currentDashTime += Time.deltaTime;
            float perc = Mathf.Clamp01(currentDashTime / dashDuration);
            transform.position = Vector3.Lerp(dashStart, dashEnd, perc);

            if (currentDashTime >= dashDuration)
            {
                isDashing = false;
                transform.position = dashEnd;
                canDash = false;
                dashCdTime = dashCd;
            }
        }
        
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 temp = context.ReadValue<Vector2>();
        if (temp != Vector2.zero)
            moveInput = new Vector3(temp.x, 0, temp.y);
        else moveInput = Vector3.zero;
    }
    public void Look(InputAction.CallbackContext context)
    {
        
        if (playerInput.currentControlScheme == "Keyboard&Mouse")
        {
            lookInput = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;
        }
        else
        {
            Vector3 temp = context.ReadValue<Vector2>();
            lookInput = new Vector3(temp.x, 0f, temp.y);
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (canShot)
        {
            GameObject bullet = (GameObject)Instantiate(projectilePrefab, shootPoint.position, playerOrientable.transform.rotation, bulletContainer);
            bullet.GetComponent<ProjectileComponent>().damage = playerDamage;
            fireRate = fireRateTreshold;
            canShot = false;
            if (Time.timeScale != 0)
                playerAudio.Play(PlayerAudio.PlayerAudioClip.Fire);
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (canDash && GameManager.instance.dashBool)
        {
            if (!meshTrail.isTrailActive)
            {
                meshTrail.isTrailActive = true;
                StartCoroutine(meshTrail.ActivateTrail(dashDuration));
            }
            
            currentDashTime = 0;
            dashStart = transform.position;
            dashEnd = transform.position + moveInput * dashDistance;
            isDashing = true;
            StartCoroutine(Dash2(dashDuration));
           
        }
    }
    public IEnumerator Dash2(float time)
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(time +0.2f);
        isInvulnerable = false;
    }

    public IEnumerator TakeDamage(int damage)
    {
        if (!isInvulnerable)
        {
            playerAudio.Play(PlayerAudio.PlayerAudioClip.Hit);
            animator.SetTrigger("Damage");
            currentHealth -= damage;
            if (currentHealth <=0)
            {
                vfxHandler.PlayAt(transform.position);
                HUDComponent.hud.EndRun();
            }
            else
            {
                HUDComponent.hud.UpdateHealth((float)currentHealth / maxHealth);
                isInvulnerable = true;
                yield return new WaitForSeconds(invulnerabilityTime);
                isInvulnerable = false;
            }
            
        }
        
        //call par les colliders du player
        //mettre une courte invuln�rabilit� a l'impact pour eviter de comptabiliser le meme impact plusieurs fois sur chaque collinder (avec une coroutine ?)
        
    }
}
