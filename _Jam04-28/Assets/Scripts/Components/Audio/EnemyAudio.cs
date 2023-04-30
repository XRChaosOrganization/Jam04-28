using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource fire;
    public AudioSource hit;
    public AudioSource kill;

    public enum EnemyAudioClip { Fire, Hit, Kill };

    public void Play(EnemyAudioClip clip)
    {
        switch (clip)
        {
            case EnemyAudioClip.Fire:
                if (fire.clip != null)
                    fire.PlayOneShot(fire.clip);
                break;
            case EnemyAudioClip.Hit:
                if (hit.clip != null)
                    hit.PlayOneShot(hit.clip);
                break;
            case EnemyAudioClip.Kill:
                if (kill.clip != null)
                    kill.PlayOneShot(kill.clip);
                break;
            default:
                break;
        }
    }
}
