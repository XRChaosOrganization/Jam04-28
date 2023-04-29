using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHandler : MonoBehaviour
{
    [SerializeField]GameObject core2D;
    [SerializeField]GameObject core3D;
    [SerializeField]GameObject frame2D;
    [SerializeField]GameObject frame3D;
    [SerializeField]GameObject wings2D;
    [SerializeField]GameObject wings3D;


    public void SetCore()
    {
        core3D.SetActive(GameManager.instance.is3D);
        core2D.SetActive(!GameManager.instance.is3D);
    }

    public void SetFrame(bool b)
    {
        frame3D.SetActive(b && GameManager.instance.is3D);
        frame2D.SetActive(b && !GameManager.instance.is3D);
    }

    public void SetWings(bool b)
    {
        wings3D.SetActive(b && GameManager.instance.is3D);
        wings2D.SetActive(b && !GameManager.instance.is3D);
    }
}
