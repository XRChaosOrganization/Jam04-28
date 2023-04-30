using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinHandler : MonoBehaviour
{
    [SerializeField] GameObject simple;
    [SerializeField] GameObject polished;

    private void Awake()
    {
        simple.SetActive(!GameManager.instance.graph2Bool);
        polished.SetActive(GameManager.instance.graph2Bool);
    }

}
