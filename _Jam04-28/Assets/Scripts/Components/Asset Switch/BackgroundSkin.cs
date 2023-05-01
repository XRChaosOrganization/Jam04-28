using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSkin : MonoBehaviour
{
    [SerializeField] Material simple;
    [SerializeField] Material polished;
    MeshRenderer mr;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        mr.material = GameManager.instance.graph2Bool ? polished : simple;
    }
}
