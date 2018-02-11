using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrehab;

    private Transform playerTransform;
    private float spawnZ = 5;

    private float interval = 6.0f;
    private int amtEnemyOnScreen = 3;

    float safeZone = 5.0f;


    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    private void Update()
    {

        //As player gets out the safe zone, spawn enemies
        if (playerTransform.position.z - safeZone > (spawnZ - amtEnemyOnScreen * interval))
        {
            SpawnEnemy();

        }
    }

    void SpawnEnemy(int prehabIndex = -1)
    {
        GameObject go;

        go = Instantiate(enemyPrehab) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = new Vector3(0, 0.3f, spawnZ);

        spawnZ += interval;
    }

}
