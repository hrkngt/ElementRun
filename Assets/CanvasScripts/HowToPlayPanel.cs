using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HowToPlayPanel : MonoBehaviour {

    /// <summary>
    /// 遊び方を表示するパネルの設定をするためのスクリプト
    /// </summary>

    public Button goBackButton;　//スタート画面に戻るボタン

    private void Start()
    {
        goBackButton.onClick.AddListener(delegate{ GameStateManager.CurrentState = GameStateManager.GameStates.INITIAL; });
    }
}
