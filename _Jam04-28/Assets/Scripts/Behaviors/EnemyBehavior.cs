using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public int damageOnHit;
    NavMeshAgent agent;

    private void Start()
    {
         agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.SetDestination(player.position);
    }
    private void OnCollisionEnter(Collision col)
    {
        //Temporaires avec prefab unités melee!
        if (col.collider.CompareTag("Player"))
        {
            player.GetComponent<PlayerCollider>().OnCollide(damageOnHit);
        }
    }
}
