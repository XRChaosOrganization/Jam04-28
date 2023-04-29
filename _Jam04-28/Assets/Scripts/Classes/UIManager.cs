using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager uIm;

    public GameObject shopMenuPanel;
    public GameObject mainMenuPanel;
    public Transform shopButtonContainer;

    public TMP_Text timerDisplay;
    public Slider HPDisplay;
    public TMP_Text goldEarnedDisplay;

    public List<Button> shopButtonsList;

    float timeCount ;
    private void Awake()
    {
        uIm = this;
        InitShopButtons();
    }

    private void Update()
    {
        timeCount += Time.deltaTime ;
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

    void InitShopButtons()
    {
        foreach (Transform shopButton in shopButtonContainer)
        {
            shopButtonsList.Add(shopButton.GetComponent<Button>());
        }
        for (int i = 0; i < shopButtonsList.Count; i++)
        {
            shopButtonsList[i].GetComponent<ShopButtonBehavior>().InitPrice();
        }
    }
    public void OpenShop()
    {
        for (int i = 0; i < shopButtonsList.Count; i++)
        {
            shopButtonsList[i].GetComponent<ShopButtonBehavior>().AdaptPriceDisplay();
        }
        mainMenuPanel.SetActive(false);
        shopMenuPanel.SetActive(true);
    }
    public void CloseShop()
    {
        mainMenuPanel.SetActive(true);
        shopMenuPanel.SetActive(false);
    }
    public void Play()
    {
        mainMenuPanel.SetActive(false);
        //Launch Game
    }
    public void UpdateHealth(float hpRatio)
    {
        HPDisplay.value = hpRatio;
    }

   
}