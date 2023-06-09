using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDComponent : MonoBehaviour
{
    public static HUDComponent hud;
    public GameObject gameOverScreen;
    public TMP_Text gameOverRecap;
    public TMP_Text timerDisplay;
    public Slider HPDisplay;
    public TMP_Text goldEarnedDisplay;
    public int goldEarned;
    public float goldTimerCoefficent;
    public Animator transition;
    float timeCount;


    public float transitionTime;

    private void Awake()
    {
        hud = this;
        //GameManager.instance.transition = transition;
        if (GameManager.instance.timerBool)
        {
            timerDisplay.gameObject.SetActive(true);
        }
        if (GameManager.instance.hpBarBool)
        {
            HPDisplay.gameObject.SetActive(true);
        }
        if (GameManager.instance.goldBool)
        {
            goldEarnedDisplay.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        timeCount += Time.deltaTime;
        float minutes = Mathf.FloorToInt(timeCount / 60);
        float seconds = Mathf.FloorToInt(timeCount % 60);
        if (seconds < 10)
        {
            timerDisplay.text = minutes + ":0" + seconds;
        }
        else
        {
            timerDisplay.text = minutes + ":" + seconds;
        }
        
        
    }
    public void UpdateHealth(float hpRatio)
    {
        HPDisplay.value = hpRatio;
    }
    public void UpdateEarnedGold(int gold)
    {
        goldEarned += gold;
        goldEarnedDisplay.text = goldEarned.ToString() + "$";
    }
    public void EndRun()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        gameOverRecap.text = "Money on time = " + timeCount.ToString() + " x " + goldTimerCoefficent.ToString() + " = " + (timeCount * goldTimerCoefficent).ToString() + "\n" + "Gold earned = " + goldEarned.ToString();
        GameManager.instance.goldAmount = Mathf.RoundToInt(timeCount * goldTimerCoefficent) + goldEarned;
    }
    public void QuitRun()
    {
        StartCoroutine(GameManager.instance.LoadScene(0));
    }


}
