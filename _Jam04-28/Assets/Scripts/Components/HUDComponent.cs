using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDComponent : MonoBehaviour
{
    public static HUDComponent hud;
    public TMP_Text timerDisplay;
    public Slider HPDisplay;
    public TMP_Text goldEarnedDisplay;
    public int goldEarned;
    float timeCount;

    private void Awake()
    {
        hud = this;
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
        if (GameManager.instance.timerBool)
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
}
