using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{
    public AudioSource nav;
    public AudioSource confirm;
    Button button;

    private void Awake()
    {
        button = GetComponentInParent<Button>();
    }

    public void PlayNav()
    {
        if(nav.clip != null && button.interactable)
            nav.PlayOneShot(nav.clip);
    }

    public void PlayConfirm()
    {
        if (confirm.clip != null && button.interactable)
            confirm.PlayOneShot(confirm.clip);
    }
}
