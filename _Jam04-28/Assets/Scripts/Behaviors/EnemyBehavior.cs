using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject coinPrefab;

    public Transform player;
    public int HP;
    public int damageOnHit;
    public int goldWorth;

    NavMeshAgent agent;

    private void Start()
    {
         agent = GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {
        agent.SetDestination(player.transform.position);
        
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP<=0)
        {
            Destroy(this.gameObject);
            GameObject coin = (GameObject)Instantiate(coinPrefab,transform.position,Quaternion.identity);
            coin.GetComponent<CoinBehavior>().gold = goldWorth;
        }
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
