using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScaler : MonoBehaviour
{
    TrailRenderer tr;
    public float widthMultiplier;

    private void Awake()
    {
        tr = GetComponent<TrailRenderer>();
        tr.widthMultiplier = widthMultiplier;
    }

    private void Update()
    {
        tr.widthMultiplier = widthMultiplier;
    }
}
