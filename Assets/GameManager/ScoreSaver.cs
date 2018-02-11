using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSaver : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static float HighScore { get; set; }



}
