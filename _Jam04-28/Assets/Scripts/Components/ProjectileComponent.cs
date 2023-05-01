using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    public float moveSpeed;
    public int damage;
    public float lifespan = 10f;

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
            col.gameObject.GetComponent<MeleeEnemyBehavior>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
