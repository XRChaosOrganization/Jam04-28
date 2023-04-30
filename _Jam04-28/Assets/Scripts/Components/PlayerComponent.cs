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

    float fireRate;
    bool canShot;
    bool Shoot1enabled;
    PlayerInput playerInput;
    Vector3 moveInput;
    Vector3 lookInput;
    ShipHandler shipHandler;
    [HideInInspector]public PlayerAudio playerAudio;

    private void Awake()
    {
        instance = this;
        playerInput = GetComponent<PlayerInput>();
        currentHealth = maxHealth;
        shipHandler = GetComponent<ShipHandler>();


        playerAudio = GetComponent<PlayerAudio>();
        
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

    public IEnumerator TakeDamage(int damage)
    {
        if (!isInvulnerable)
        {
            playerAudio.Play(PlayerAudio.PlayerAudioClip.Hit);
            currentHealth -= damage;
            if (currentHealth <=0)
            {
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
