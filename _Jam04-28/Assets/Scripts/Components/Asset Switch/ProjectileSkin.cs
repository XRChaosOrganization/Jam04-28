using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSkin : MonoBehaviour
{
    
    [SerializeField] bool isPlayer;

    [Header("Mesh")]
    [SerializeField] GameObject simple;
    [SerializeField] GameObject polished;
    [SerializeField] GameObject normalTrail;
    [SerializeField] GameObject rainbowTrail;

    private void Awake()
    {
        simple.SetActive(!GameManager.instance.graph2Bool);
        polished.SetActive(GameManager.instance.graph2Bool);
        if (GameManager.instance.isFeverTime && isPlayer)
        {
            normalTrail.SetActive(false);
            rainbowTrail.SetActive(GameManager.instance.graph2Bool);
        }
        else
        {
            normalTrail.SetActive(GameManager.instance.graph2Bool);
            if(rainbowTrail != null)
                rainbowTrail.SetActive(false);
        }
    }
}
