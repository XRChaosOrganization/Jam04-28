using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ProjectileComponent : MonoBehaviour
{
    public float moveSpeed;
    public int damage;
    public float lifespan = 10f;
    VFX_Handler vfx;

    private void Awake()
    {
        vfx = GetComponent<VFX_Handler>();
    }

    private void Start()
    {
        Destroy(this.gameObject, lifespan);
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
            vfx.PlayAt(transform.position);

            col.gameObject.GetComponent<MeleeEnemyBehavior>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
