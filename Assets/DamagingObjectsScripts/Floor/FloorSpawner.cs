using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour {

    public GameObject[] floorPrehabs;

    private Transform playerTransform;
    private float spawnZ = -2;

    private float groundLength = 2;
    private int amtGroundOnScreen = 10;

    private List<GameObject> activeFloor;
    private float safeZone = 2;

    bool isSafe = true;

    private void Awake()
    {
        activeFloor = new List<GameObject>();

        playerTransform = GameObject.Find("Player").transform;
        for (int i = 0; i <= amtGroundOnScreen; i++)
        {
            SpawnFloor(true);
        }
    }


    private void Update()
    {
        if (playerTransform.position.z - safeZone > spawnZ - amtGroundOnScreen * groundLength)
        {
            SpawnFloor(isSafe); 
            DeleteGround();

            //Ensures damage floors do not continuity
            isSafe = (isSafe) ? false : true;
        }
    }

    void SpawnFloor(bool safe)
    {
        GameObject go;

        //if safe is false, randomly spawn damage floors
        int a = (safe) ? 0 : Random.Range(0, 4);

        //Create safe floor object
        go = Instantiate(floorPrehabs[a]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += groundLength;
        activeFloor.Add(go);
    }

    void DeleteGround()
    {
        Destroy(activeFloor[0]);
        activeFloor.RemoveAt(0);
    }
}
