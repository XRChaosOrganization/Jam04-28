using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    public GameObject ground;
    public BoxCollider col;
    public float spawnRateTreshold;
    public Transform enemyContainer;
    public GameObject enemyPrefab;
    float spawnRate;
    public List<Vector3> corners;
    public Transform player;


    private void Awake()
    {
        col = GetComponent<BoxCollider>();
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
            
        }
    }
    void SpawnEnemy()
    {
        Vector3 rand = RandomSpawnLocation(Random.Range(0, 4), (float)Random.Range(0, 100) / 100);
        GameObject enemyInstance = (GameObject)Instantiate(enemyPrefab, rand, Quaternion.identity, enemyContainer);
        // FAIRE UN SWITCH SELON LENNEMI INSTANCIE
        enemyInstance.GetComponent<RangeTriShotEnemyBehavior>().player = player;
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
        Vector3 cornerA = new Vector3(col.center.x - col.size.x / 2,0f, col.center.z + col.size.z / 2);
        Vector3 cornerB = new Vector3(col.center.x + col.size.x / 2,0f, col.center.z + col.size.z / 2);
        Vector3 cornerC = new Vector3(col.center.x + col.size.x / 2,0f, col.center.z - col.size.z / 2);
        Vector3 cornerD = new Vector3(col.center.x - col.size.x / 2,0f, col.center.z - col.size.z / 2);
        
        Debug.Log(col.bounds);
        corners.Add(cornerA);
        corners.Add(cornerB);
        corners.Add(cornerC);
        corners.Add(cornerD);

    }
}
