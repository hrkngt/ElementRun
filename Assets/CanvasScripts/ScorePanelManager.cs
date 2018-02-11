using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    float highscore;

    private void Start()
    {
        //Get highest score before start playing
        highscore = PlayerPrefs.GetFloat("HIGHSCORE");
    }

    private void Update()
    {
        if (ScoreManager.Score > highscore)
        {
            //When player reaches highscore, make the score text red
            scoreText.color = Color.red;

        }

        //update score panel
        scoreText.text = ScoreManager.Score.ToString("n1") + " m";
        

    }

}
