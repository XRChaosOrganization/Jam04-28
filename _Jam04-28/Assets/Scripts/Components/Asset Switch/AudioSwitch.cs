using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSwitch : MonoBehaviour
{
    enum AudioType { BGM, SFX };
    [SerializeField] AudioType audioType;

    [Space]

    [SerializeField] AudioClip clip1;
    [SerializeField] AudioMixerGroup mixer1;
    [Space]
    [SerializeField] AudioClip clip2;
    [SerializeField] AudioMixerGroup mixer2;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Start()
    {
        if (GameManager.instance.sound2Bool)
        {
            audioSource.clip = clip2;
            audioSource.outputAudioMixerGroup = mixer2;
        }
        else if (Level1Check())
        {
            audioSource.clip = clip1;
            audioSource.outputAudioMixerGroup = mixer1;
        }
    }

    bool Level1Check()
    {
        if (audioType == AudioType.BGM && GameManager.instance.music1Bool)
            return true;
        if (audioType == AudioType.SFX && GameManager.instance.sFX1Bool)
            return true;
        return false;
    }
}
