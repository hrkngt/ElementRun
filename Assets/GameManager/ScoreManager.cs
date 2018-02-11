using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static float Score { get; set; }
    private float startingPoint; //used to store the position where player starts

    private void Start()
    {
        startingPoint = MovementManager.PlayerTransform.position.z;
    }

    private void Update()
    {
        //calculate score based on how far player gets
        Score = MovementManager.PlayerTransform.position.z - startingPoint;

        //Save highscore
        if (Score > PlayerPrefs.GetFloat("HIGHSCORE"))
        {
            PlayerPrefs.SetFloat("HIGHSCORE", Score);
        }
        
    }



}
