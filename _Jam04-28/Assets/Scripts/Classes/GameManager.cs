using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool is3D;
    public int goldAmount = 0;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);

    }

    public void Unlock(string unlockCode)
    {
        switch (unlockCode)
        {
            case "Gold":
                UIManager.uIm.goldEarnedDisplay.gameObject.SetActive(true);
                break;
            case "HPBar":
                UIManager.uIm.HPDisplay.gameObject.SetActive(true);
                break;
            case "Timer":
                UIManager.uIm.timerDisplay.gameObject.SetActive(true);
                break;
            case "MS1":
                break;
            case "SFX1":
                break;
            case "Shoot1":
                break;
            case "Music1":
                break;
            case "VFX1":
                break;
            case "MS2":
                break;
            case "Dash":
                break;
            case "VFX2":
                break;
            case "Dash2":
                break;
            case "Juice":
                break;
            case "Fever":
                break;
            default:
                break;
        }
    }

    
}
