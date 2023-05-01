using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFX_Handler : MonoBehaviour
{
    [SerializeField] GameObject simple;
    [SerializeField] GameObject polished;
    [SerializeField] float lifetime = 4f;
    

    public void PlayAt(Vector3 v)
    {
        GameObject targetGO = null;
        if (GameManager.instance.graph2Bool)
            targetGO = polished != null ? polished : simple;
            
        if (GameManager.instance.vfx1Bool)
            targetGO = simple;

        if (targetGO != null)
        {
            GameObject vfxGO = (GameObject)Instantiate(targetGO, v, Quaternion.identity);
            VisualEffect vfx = vfxGO.GetComponent<VisualEffect>();
            vfx.Play();

            Destroy(vfxGO, lifetime);
        }

    }

}
