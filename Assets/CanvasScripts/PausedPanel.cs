using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausedPanel : MonoBehaviour {

    /// <summary>
    /// ポーズ状態のときに表示されるパネルの設定をするためのスクリプト
    /// </summary>

    public Button pauseButton;　　//ポーズボタン
    public Button resumeButton;　 //再開ボタン
    public Button resetButton;　　//リセットボタン

    private void Start()
    {
        //ゲームをポーズする
        pauseButton.onClick.AddListener(delegate { GameStateManager.CurrentState = GameStateManager.GameStates.PAUSED; });

        //ゲームを再開
        resumeButton.onClick.AddListener(delegate { GameStateManager.CurrentState = GameStateManager.GameStates.RUNNING; });

        //リセットボタンが押された際
        resetButton.onClick.AddListener(delegate {
            //INITIAL状態に設定の上、
            GameStateManager.CurrentState = GameStateManager.GameStates.INITIAL;
            //シーンをリセット
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }

}
