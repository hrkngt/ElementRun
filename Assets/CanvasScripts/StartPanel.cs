using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour {

    public Button startButton;
    public Button howToPlayButton;

    private void Start()
    {
        startButton.onClick.AddListener(delegate { GameStateManager.CurrentState = GameStateManager.GameStates.RUNNING; });
        howToPlayButton.onClick.AddListener(delegate { GameStateManager.CurrentState = GameStateManager.GameStates.TUTORIAL; });
    }
}
