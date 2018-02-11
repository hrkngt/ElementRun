using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject player;
    public Camera mainCamera;
    private Vector3 offset = Vector3.zero;

    void Start()
    {
        offset = mainCamera.transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = mainCamera.transform.position;
        newPosition.x = player.transform.position.x + offset.x;
        //newPosition.y = player.transform.position.y + offset.y;
        newPosition.z = player.transform.position.z + offset.z;
        mainCamera.transform.position = newPosition;
    }
}
