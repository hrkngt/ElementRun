using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultPanel : MonoBehaviour {

    /// <summary>
    /// ゲームオーバー時に表示されるリザルトパネルの内容を操作するためのスクリプト
    /// </summary>

    public Text resultScoreText;   //そのときのスコアを表示する
    public Text highestScoreText;  //ハイスコアを表示する
    public Button retryButton;     //リトライボタン

    private void Start()
    {
        //リトライボタンが押される　→　シーンをリセット
        retryButton.onClick.AddListener(delegate {
            GameStateManager.CurrentState = GameStateManager.GameStates.INITIAL;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        });
    }

    private void Update()
    {
        if(GameStateManager.CurrentState == GameStateManager.GameStates.GAMEOVER)
        {
            resultScoreText.text = ScoreManager.Score.ToString("n1") + " m";
            highestScoreText.text = PlayerPrefs.GetFloat("HIGHSCORE").ToString("n1") + " m";
        }
    }
}
