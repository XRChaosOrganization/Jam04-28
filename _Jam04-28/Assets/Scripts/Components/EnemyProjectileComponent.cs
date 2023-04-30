using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileComponent : MonoBehaviour
{
    public float moveSpeed;
    public int damage;

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerCollider>().OnCollide(damage);
            Destroy(this.gameObject);
        }
    }
}
