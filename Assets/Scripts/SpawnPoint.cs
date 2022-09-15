using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject spawnObject;
    public float initialTime = 0;
    public float timeToSpawn = 3;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", initialTime, timeToSpawn);
    }

    void SpawnObject()
    {
        if(EnemyManager.s_enemyCount < EnemyManager.s_enemyLimit)
        {
            GameObject instance = Instantiate(spawnObject, transform.position, Quaternion.identity);
            EnemyManager.s_enemyCount++;
        }
    }
}
