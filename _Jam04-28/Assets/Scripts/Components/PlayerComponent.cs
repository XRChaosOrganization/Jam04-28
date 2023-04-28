using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerComponent : MonoBehaviour
{
    public float playerMoveSpeed;
    public int maxHealth;
    public int currentHealth;

    Vector3 moveInput;
   
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
}
