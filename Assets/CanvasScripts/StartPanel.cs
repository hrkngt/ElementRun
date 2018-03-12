using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour {

    /// <summary>
    /// スタート画面のパネルの表示設定をするためのスクリプト
    /// </summary>

    public Button startButton;　　　//ゲーム開始ボタン
    public Button howToPlayButton;　//遊び方を表示するボタン

    private void Start()
    {
        //各ボタンが押された際の動作を設定
        startButton.onClick.AddListener(delegate { GameStateManager.CurrentState = GameStateManager.GameStates.RUNNING; });
        howToPlayButton.onClick.AddListener(delegate { GameStateManager.CurrentState = GameStateManager.GameStates.TUTORIAL; });
    }
}
