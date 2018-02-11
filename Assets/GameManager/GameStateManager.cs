using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

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
        CurrentState = GameStates.INITIAL;
    }






}
