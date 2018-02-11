using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausedPanel : MonoBehaviour {

    public Button pauseButton;
    public Button resumeButton;
    public Button resetButton;

    private void Start()
    {
        pauseButton.onClick.AddListener(delegate { GameStateManager.CurrentState = GameStateManager.GameStates.PAUSED; });
        resumeButton.onClick.AddListener(delegate { GameStateManager.CurrentState = GameStateManager.GameStates.RUNNING; });
        resetButton.onClick.AddListener(delegate {
            GameStateManager.CurrentState = GameStateManager.GameStates.INITIAL;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }

}
