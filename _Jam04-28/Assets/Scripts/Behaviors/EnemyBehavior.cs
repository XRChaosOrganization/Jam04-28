using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    NavMeshAgent agent;

    private void Start()
    {
         agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.SetDestination(player.position);
    }
}
