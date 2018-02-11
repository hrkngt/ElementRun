using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultPanel : MonoBehaviour {

    public Text resultScoreText;
    public Text highestScoreText;
    public Button retryButton;

    FadeManager fadeManager;

    private void Start()
    {
        fadeManager = GameObject.Find("_SCRIPTS_").GetComponent<FadeManager>();

        //Reload current scene
        retryButton.onClick.AddListener(delegate {
            fadeManager.Fade(false, 0.5f);
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
