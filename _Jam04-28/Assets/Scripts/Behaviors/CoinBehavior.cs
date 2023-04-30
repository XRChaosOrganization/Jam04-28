using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public int gold;

    
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            HUDComponent.hud.UpdateEarnedGold(gold);
            PlayerComponent.instance.playerAudio.Play(PlayerAudio.PlayerAudioClip.Pickup);
            Destroy(this.gameObject);
        }
    }
}
