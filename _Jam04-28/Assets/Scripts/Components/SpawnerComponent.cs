using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    public GameObject ground;
    public BoxCollider col;
    public float spawnRateTreshold;
    public Transform enemyContainer;
    public Transform bulletContainer;
    public GameObject enemyPrefab;
    float spawnRate;
    public List<Vector3> corners;
    public Transform player;


    private void Awake()
    {
        GetCorners();
        spawnRate = spawnRateTreshold;
        
    }
    private void Update()
    {
        spawnRate -= Time.deltaTime;
        
        if (spawnRate <= 0)
        {
            spawnRate = spawnRateTreshold;
            SpawnEnemy();
            corners.Clear();
            GetCorners();
        }
    }
    void SpawnEnemy()
    {
        Vector3 rand = RandomSpawnLocation(Random.Range(0, 4), (float)Random.Range(0, 100) / 100);
        GameObject enemyInstance = (GameObject)Instantiate(enemyPrefab, rand, Quaternion.identity, enemyContainer);
        // FAIRE UN SWITCH SELON LENNEMI INSTANCIE
        enemyInstance.GetComponent<RangeTriShotEnemyBehavior>().player = player;
        enemyInstance.GetComponent<RangeTriShotEnemyBehavior>().bulletContainer = bulletContainer;
    }
    Vector3 RandomSpawnLocation(int c, float r)
    {
        if (c == 3)
        {
            return Vector3.Lerp(corners[c], corners[0], r);
        }
        else
        {
            return Vector3.Lerp(corners[c], corners[c + 1], r);
        }
    }
    void GetCorners()
    {
        Vector3 cornerA = new Vector3(player.transform.position.x - col.size.x / 2,0f, player.transform.position.z + col.size.z / 2);
        Vector3 cornerB = new Vector3(player.transform.position.x + col.size.x / 2,0f, player.transform.position.z + col.size.z / 2);
        Vector3 cornerC = new Vector3(player.transform.position.x + col.size.x / 2,0f, player.transform.position.z - col.size.z / 2);
        Vector3 cornerD = new Vector3(player.transform.position.x - col.size.x / 2,0f, player.transform.position.z - col.size.z / 2);
        corners.Add(cornerA);
        corners.Add(cornerB);
        corners.Add(cornerC);
        corners.Add(cornerD);

    }
}
