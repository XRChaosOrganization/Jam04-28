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
    public TMP_Text goldAmountText;

    public List<Button> shopButtonsList;

    private void Awake()
    {
        uIm = this;
        
        InitShopButtons();
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
        goldAmountText.text = GameManager.instance.goldAmount.ToString() + "$";
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
        StartCoroutine(GameManager.instance.LoadScene(1));
    }

   


   
}