using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButtonBehavior : MonoBehaviour
{
    public int price;
    public TMP_Text pricetext;
    public string unlockKeyWord;
    public TMP_Text shopDenyDisplay;


    public void BuyUnlock()
    {
        if (GameManager.instance.goldAmount>=price)
        {
            GameManager.instance.Unlock(unlockKeyWord);
            GameManager.instance.goldAmount -= price;
        }
        else
        {
            shopDenyDisplay.gameObject.SetActive(true);
        }
        

    }
    public void InitPrice()
    {
        pricetext.text = "Cost :" + price.ToString() + "$";
    }
    public void AdaptPriceDisplay()
    {
        if (GameManager.instance.goldAmount>=price)
        {
            pricetext.color = Color.green;
        }
        else
        {
            pricetext.color = Color.red;
        }
    }
    
}
