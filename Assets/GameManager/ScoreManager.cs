using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    /// <summary>
    /// プレイヤーが進んだ距離に応じてスコアを算出するためのスクリプト
    /// </summary>

	public static float Score { get; set; } //スコア
    private float startingPoint; //プレイヤーの初期位置を格納するために使用

    private void Start()
    {
        //プレイヤーの初期位置を格納
        startingPoint = MovementManager.PlayerTransform.position.z;
    }

    private void Update()
    {
        //プレイヤーの移動距離に応じてスコアを算出
        Score = MovementManager.PlayerTransform.position.z - startingPoint;

        //ハイスコアを格納
        if (Score > PlayerPrefs.GetFloat("HIGHSCORE"))
        {
            PlayerPrefs.SetFloat("HIGHSCORE", Score);
        }
        
    }



}
