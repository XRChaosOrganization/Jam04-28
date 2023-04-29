using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerComponent : MonoBehaviour
{
    public static PlayerComponent instance;
    ShipHandler shipHandler;
    public GameObject playerOrientable; //Le GameObject � rotate pour face une direction;
    
    public float playerMoveSpeed;
    public float rotationSpeed;
    public int maxHealth;
    public int currentHealth;
    public bool isInvulnerable;
    public float invulnerabilityTime;
    PlayerInput playerInput;

    Vector3 moveInput;
    Vector3 lookInput;

    private void Awake()
    {
        instance = this;
        playerInput = GetComponent<PlayerInput>();
        currentHealth = maxHealth;
       // shipHandler = GetComponent<ShipHandler>();
       // shipHandler.SetCore();
        //shipHandler.SetFrame(bool) avec bool true si frame unlock
        //shipHandler.SetWings(bool) avec bool true si wings unlock
        
    }

    private void Update()
    {
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
            lookInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            Vector3 temp = context.ReadValue<Vector2>();
            lookInput = new Vector3(temp.x, 0f, temp.y);
        }
        
        
    }

    public IEnumerator TakeDamage(int damage)
    {
        if (!isInvulnerable)
        {
            currentHealth -= damage;
            UIManager.uIm.UpdateHealth((float)currentHealth / maxHealth);
            isInvulnerable = true;
            yield return new WaitForSeconds(invulnerabilityTime);
            isInvulnerable = false;
        }
        
        //call par les colliders du player
        //mettre une courte invuln�rabilit� a l'impact pour eviter de comptabiliser le meme impact plusieurs fois sur chaque collinder (avec une coroutine ?)
        
    }
}
