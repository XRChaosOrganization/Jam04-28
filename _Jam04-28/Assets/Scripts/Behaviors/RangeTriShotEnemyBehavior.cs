using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeTriShotEnemyBehavior : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject enemyProjectilePrefab;
    public List<GameObject> shootPoints;
    public Transform player;
    public Transform bulletContainer;
    public int HP;
    public int damageOnHit;
    public int goldWorth;
    public float range;
    public float fireRate;

    float fireRateTime;
    NavMeshAgent agent;
    VFX_Handler vfxHandler;

    [HideInInspector] public EnemyAudio enemyAudio;

    private void Awake()
    {
        enemyAudio = GetComponent<EnemyAudio>();
        vfxHandler = GetComponent<VFX_Handler>();
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        fireRateTime = fireRate;

    }
    private void Update()
    {

        agent.SetDestination(player.transform.position);
        fireRateTime -= Time.deltaTime;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance<= range)
        {
            agent.isStopped = true;
            if (fireRateTime<=0)
            {
                fireRateTime = fireRate;
                for (int i = 0; i < shootPoints.Count; i++)
                {
                    Debug.Log(i);
                    GameObject shotGO = Instantiate(enemyProjectilePrefab, shootPoints[i].transform.position, shootPoints[i].transform.rotation, bulletContainer.transform);
                    shotGO.GetComponent<EnemyProjectileComponent>().damage = damageOnHit;
                }
                
            }
        }
        else
        {
            agent.isStopped = false;
        }

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

        if (col.collider.CompareTag("Player"))
        {
            if (player.GetComponent<PlayerComponent>().isDashing && GameManager.instance.dash2Bool)
            {
                TakeDamage(player.GetComponent<PlayerComponent>().dashDamage);
            }
            else
            {
                player.GetComponent<PlayerCollider>().OnCollide(damageOnHit);
            }

        }
    }

    IEnumerator KillEnemy()
    {
        vfxHandler.PlayAt(transform.position);
        transform.Find("Mesh").gameObject.SetActive(false);
        GameObject coin = (GameObject)Instantiate(coinPrefab, transform.position, Quaternion.identity);
        coin.GetComponent<CoinBehavior>().gold = goldWorth;
        enemyAudio.Play(EnemyAudio.EnemyAudioClip.Kill);

        yield return new WaitWhile(() => enemyAudio.kill.isPlaying);

        Destroy(this.gameObject);

    }
}
