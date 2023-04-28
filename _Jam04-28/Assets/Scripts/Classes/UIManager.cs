using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public void Play()
    {
        mainMenuPanel.SetActive(false);
        //Launch Game
    }
}
