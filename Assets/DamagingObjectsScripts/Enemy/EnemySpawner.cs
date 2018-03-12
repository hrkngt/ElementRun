using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    /// <summary>
    /// 敵オブジェクトを自動生成するためのスクリプト
    /// </summary>

    public GameObject enemyPrehab;　　　//敵オブジェクト

    private Transform playerTransform;　//プレイヤーオブジェクト
    private float spawnZ = 5;　　　　　 //生成される敵オブジェクトのZ座標

    private float interval = 6.0f;　　　//敵オブジェクト同士の間隔
    private int amtEnemyOnScreen = 3;　 //ゲーム内に存在する敵オブジェクトの数

    float safeZone = 5.0f;　　　　　　　//敵が出ない安全地帯を設定するのに使用


    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    private void Update()
    {

        //プレイヤー安全地帯を抜けて一定距離進んだ際に敵オブジェクトを生成
        if (playerTransform.position.z - safeZone > (spawnZ - amtEnemyOnScreen * interval))
        {
            //敵を生成
            SpawnEnemy();
        }
    }

    //ランダムな属性の敵を生成
    void SpawnEnemy(int prehabIndex = -1)
    {
        GameObject go;　//敵オブジェクトを一時格納するために使用

        //敵オブジェクトのコピーを格納
        go = Instantiate(enemyPrehab) as GameObject;　

        //親オブジェクトを設定
        go.transform.SetParent(transform);

        //生成する座標を設定
        go.transform.position = new Vector3(0, 0.3f, spawnZ);

        //間隔分、次の敵オブジェクトのZ座標を更新
        spawnZ += interval;
    }

}
