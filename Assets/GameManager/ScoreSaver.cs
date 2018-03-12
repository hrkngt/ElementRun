using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSaver : MonoBehaviour {

    /// <summary>
    /// ハイスコアを格納するためのスクリプト
    /// </summary>

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static float HighScore { get; set; }



}
