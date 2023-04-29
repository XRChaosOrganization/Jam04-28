using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public int gold;

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Player"))
        {
            HUDComponent.hud.UpdateEarnedGold(gold);
            Destroy(this.gameObject);
        }
    }
}