using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    /// <summary>
    /// カメラの位置を追尾するオブジェクトに位置に応じて随時変更するためのスクリプト
    /// </summary>

    public GameObject objectToFollow;　//カメラが追尾するオブジェクト
    private Vector3 offset = Vector3.zero;　//追尾するオブジェクトに対するカメラの位置

    void Start()
    {
        //現在のカメラと追尾するオブジェクトの位置からオフセットを算出し格納
        offset = transform.position - objectToFollow.transform.position;
    }

    void Update()
    {
        //新しいカメラの位置を格納
        Vector3 newPosition = transform.position;

        //カメラの位置を追尾するオブジェクトとのオフセットに応じて変更
        newPosition.x = objectToFollow.transform.position.x + offset.x;
        newPosition.z = objectToFollow.transform.position.z + offset.z;

        //格納された新しいカメラの位置に実際のカメラを移動
        transform.position = newPosition;
    }
}
