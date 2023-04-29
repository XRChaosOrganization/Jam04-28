using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool is3D;
    public int goldAmount = 0;

    public bool goldBool;
    public bool hpBarBool;
    public bool timerBool;
    public bool ms1Bool;
    public bool sFX1Bool;
    public bool shoot1Bool;
    public bool music1Bool;
    public bool vfx1Bool;
    public bool ms2Bool;
    public bool dashBool;
    public bool vFX2Bool;
    public bool dash2Bool;
    public bool juiceBool;
    public bool feverBool;


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
                goldBool = true;
                break;
            case "HPBar":
                hpBarBool = true;
                break;
            case "Timer":
                timerBool = true;
                break;
            case "MS1":
                ms1Bool = true;
                break;
            case "SFX1":
                sFX1Bool = true;
                break;
            case "Shoot1":
                shoot1Bool = true;
                break;
            case "Music1":
                music1Bool = true;
                break;
            case "VFX1":
                vfx1Bool = true;
                break;
            case "MS2":
                ms2Bool = true;
                break;
            case "Dash":
                dashBool = true;
                break;
            case "VFX2":
                vFX2Bool = true;
                break;
            case "Dash2":
                dash2Bool = true;
                break;
            case "Juice":
                juiceBool = true;
                //Nouvelle Camera
                break;
            case "Fever":
                feverBool = true;
                break;
            default:
                break;
        }
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void UpdateGold()
    {

    }
}
