using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTrail : MonoBehaviour
{
    public bool isTrailActive;
    public float meshRefreshRate = 0.1f;
    public float meshDestroyDelay = 3f;
    MeshFilter[] meshFilters;
    SpriteRenderer[] spriteRenderers;
    public Transform positionToSpawn;
    public Vector3 meshPosOffset;
    public Vector3 sizeOffset;
    public Material meshMaterial;
    public Material spriteMaterial;
    public float alphaRate = 0.1f;
    public float alphaRefeshRate = 0.05f;
    

    public IEnumerator ActivateTrail(float timeActive)
    {
        while (timeActive > 0)
        {
            timeActive -= meshRefreshRate;

            if (meshFilters == null)
                meshFilters = GetComponentsInChildren<MeshFilter>();

            if (spriteRenderers == null)
                spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

            //Handle Mesh Part
            for (int i = 0; i < meshFilters.Length; i++)
            {
                GameObject gObj = new GameObject();

                gObj.transform.localScale = sizeOffset;
                gObj.transform.position = positionToSpawn.position + meshPosOffset ;
                gObj.transform.rotation = positionToSpawn.rotation;
                gObj.transform.Rotate(new Vector3(-90f, 0f, 0f));

                MeshRenderer mr = gObj.AddComponent<MeshRenderer>();
                MeshFilter mf = gObj.AddComponent<MeshFilter>();


                mf.mesh = meshFilters[i].mesh;
                mr.material = meshMaterial;

                StartCoroutine(AnimateMatAlpha(mr.material));

                Destroy(gObj, meshDestroyDelay);

            }

            //Handle Sprite Part
            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                GameObject gObj = new GameObject();

                gObj.transform.localScale = sizeOffset;
                gObj.transform.position = spriteRenderers[i].gameObject.transform.position;
                gObj.transform.rotation = positionToSpawn.rotation;
                gObj.transform.Rotate(new Vector3(90f, 0f, 0f));

                SpriteRenderer sr = gObj.AddComponent<SpriteRenderer>();
                sr.sprite = spriteRenderers[i].sprite;
                sr.material = spriteMaterial;

                StartCoroutine(AnimateMatAlpha(sr.material));

                Destroy(gObj, meshDestroyDelay);
            }



            yield return new WaitForSeconds(meshRefreshRate);
        }

        isTrailActive = false;
    }

    IEnumerator AnimateMatAlpha(Material mat)
    {
        float alpha = mat.GetFloat("_Alpha");

        while (alpha > 0)
        {
            alpha -= alphaRate;
            mat.SetFloat("_Alpha", alpha);
            yield return new WaitForSeconds(alphaRefeshRate);
        }
    }


}
