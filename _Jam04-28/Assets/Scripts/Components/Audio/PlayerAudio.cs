using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    [SerializeField] AudioSource fire;
    [SerializeField] AudioSource hit;
    [SerializeField] AudioSource pickup;

    public enum PlayerAudioClip { Fire, Hit, Pickup};
    
    public void Play(PlayerAudioClip clip)
    {
        switch (clip)
        {
            case PlayerAudioClip.Fire:
                if(fire.clip != null)
                    fire.PlayOneShot(fire.clip);
                break;
            case PlayerAudioClip.Hit:
                if (hit.clip != null)
                    hit.PlayOneShot(hit.clip);
                break;
            case PlayerAudioClip.Pickup:
                if(GameManager.instance.sFX1Bool)
                    pickup.PlayOneShot(pickup.clip);
                break;
            default:
                break;
        }
    }

}
