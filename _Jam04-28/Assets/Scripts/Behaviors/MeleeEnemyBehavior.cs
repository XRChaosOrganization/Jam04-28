using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyBehavior : MonoBehaviour
{
    public GameObject coinPrefab;

    public Transform player;
    public int HP;
    public int damageOnHit;
    public int goldWorth;

    NavMeshAgent agent;
    [HideInInspector] public EnemyAudio enemyAudio;

    private void Awake()
    {
        enemyAudio = GetComponent<EnemyAudio>();
    }

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
        enemyAudio.Play(EnemyAudio.EnemyAudioClip.Hit);
        HP -= damage;
        if (HP <= 0)
            StartCoroutine(KillEnemy());

    }
    private void OnCollisionEnter(Collision col)
    {
        //Temporaires avec prefab unités melee!
        if (col.collider.CompareTag("Player"))
        {
            player.GetComponent<PlayerCollider>().OnCollide(damageOnHit);
        }
    }

    IEnumerator KillEnemy()
    {
        transform.Find("Mesh").gameObject.SetActive(false);
        GameObject coin = (GameObject)Instantiate(coinPrefab, transform.position, Quaternion.identity);
        coin.GetComponent<CoinBehavior>().gold = goldWorth;
        enemyAudio.Play(EnemyAudio.EnemyAudioClip.Kill);

        yield return new WaitWhile(() => enemyAudio.kill.isPlaying);

        Destroy(this.gameObject);

    }
}
