using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerComponent : MonoBehaviour
{
    public static PlayerComponent instance;
    ShipHandler shipHandler;
    public GameObject playerOrientable; //Le GameObject à rotate pour face une direction;
    
    public float playerMoveSpeed;
    public int maxHealth;
    public int currentHealth;
    public bool isInvulnerable;

    Vector3 moveInput;

    private void Awake()
    {
        instance = this;
        shipHandler = GetComponent<ShipHandler>();
        shipHandler.SetCore();
        //shipHandler.SetFrame(bool) avec bool true si frame unlock
        //shipHandler.SetWings(bool) avec bool true si wings unlock

    }

    private void Update()
    {
        transform.position += moveInput * playerMoveSpeed * Time.deltaTime;
    }
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 temp = context.ReadValue<Vector2>();
        if (temp != Vector2.zero)
            moveInput = new Vector3(temp.x, 0, temp.y);
        else moveInput = Vector3.zero;
    }

    public void TakeDamage(int damage)
    {
        //call par les colliders du player
        //mettre une courte invulnérabilité a l'impact pour eviter de comptabiliser le meme impact plusieurs fois sur chaque collinder (avec une coroutine ?)
    }
}
