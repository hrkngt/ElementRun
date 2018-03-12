using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    /// <summary>
    /// ゲームの状態を制御するためのスクリプト
    /// </summary>

	public enum GameStates
    {
        INITIAL,
        TUTORIAL,
        RUNNING,
        GAMEOVER,
        PAUSED
    }

    public static GameStates CurrentState { get; set; }

    private void Awake()
    {
        //シーン開始時のゲームの状態を設定
        CurrentState = GameStates.INITIAL;
    }






}
