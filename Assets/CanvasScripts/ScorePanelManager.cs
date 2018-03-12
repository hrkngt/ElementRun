using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelManager : MonoBehaviour {

    /// <summary>
    /// ゲーム中に表示されるスコアパネルの設定をするためのスクリプト
    /// </summary>

    public Text scoreText;　　　//現在のスコアを表示するのに使用

    float highscore;　　　　　　//ハイスコアを格納するのに使用

    private void Start()
    {
        //プレイ開始前のハイスコア取得
        highscore = PlayerPrefs.GetFloat("HIGHSCORE");
    }

    private void Update()
    {
        if (ScoreManager.Score > highscore)
        {
            //ハイスコアを超えた際にテキストの色を赤くする
            scoreText.color = Color.red;
        }

        //スコアテキストを更新
        scoreText.text = ScoreManager.Score.ToString("n1") + " m";
        

    }

}
