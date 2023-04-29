using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public void OnCollide(int damage)
    {
        PlayerComponent.instance.TakeDamage(damage);
        //Passer les degats depuis le projectile
    }
}
