using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour {

    /// <summary>
    /// フロアの生成を設定するためのスクリプト
    /// </summary>

    public GameObject[] floorPrehabs;　　　//フロアオブジェクト

    private Transform playerTransform;　　 //プレイヤーオブジェクト
    private float spawnZ = -2;　　　　　　 //生成されるフロアのZ座標

    private float groundLength = 2;　   　 //フロアの長さ
    private int amtGroundOnScreen = 10;　　//ゲーム内に存在するフロアの数

    private List<GameObject> activeFloor;　//フロアを削除等管理する際に使用
    private float safeZone = 2;　　　　　　//プレイヤーの後ろに存在するフロアを設定する際に使用

    bool isSafe = true;　　　　　　　　　　//プレイヤーが安全地帯内にいるかどうかを確認するために使用

    private void Awake()
    {
        activeFloor = new List<GameObject>();

        playerTransform = GameObject.Find("Player").transform;

        //ゲーム開始時の安全なフロアを用意
        for (int i = 0; i <= amtGroundOnScreen; i++)
        {
            SpawnFloor(true);
        }
    }


    private void Update()
    {
        //プレイヤーが安全地帯を抜けて一定距離進んだ際に次々フロアを生成
        if (playerTransform.position.z - safeZone > spawnZ - amtGroundOnScreen * groundLength)
        {
            //フロアを生成
            SpawnFloor(isSafe);

            //最も古いフロアを削除
            DeleteGround();

            //ダメージフロアが2つ以上続くのを防ぐ
            isSafe = (isSafe) ? false : true;
        }
    }

    void SpawnFloor(bool isSafe)
    {
        GameObject go; //フロアオブジェクトを一時格納するために使用

        //isSafeがfalseであれば、ランダムな属性のダメージフロアを生成
        int a = (isSafe) ? 0 : Random.Range(0, 4);

        //フロアを生成
        go = Instantiate(floorPrehabs[a]) as GameObject;
        
        //親オブジェクトを設定
        go.transform.SetParent(transform);

        //フロアオブジェクトの座標を設定
        go.transform.position = Vector3.forward * spawnZ;

        //次のフロアオブジェクトのZ座標を更新
        spawnZ += groundLength;

        //リストに生成されたフロアオブジェクトを追加
        activeFloor.Add(go);
    }

    void DeleteGround()　//不要になったフロアの削除
    {
        //オブジェクトの削除
        Destroy(activeFloor[0]);

        //リストから削除
        activeFloor.RemoveAt(0);
    }
}
