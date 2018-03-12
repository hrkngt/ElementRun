
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour {

    /// <summary>
    /// プレイヤーの体力に応じてヘルスバーを更新するためのスクリプト
    /// </summary>

    public Image healthBar; //プレイヤーの体力によって収縮する画像
    float maxHealth;        //プレイヤーの体力の最大値を格納するために使用

    private void Start()
    {
        maxHealth = PlayerManager.Health; //体力の最大値を格納
    }


    private void Update()
    {
        if (PlayerManager.Health > 0)
        {
            //プレイヤーの体力の最大値と現在地の割合に応じてヘルスバーを収縮
            healthBar.transform.localScale = new Vector2(PlayerManager.Health / maxHealth, 1);
        }
        else 
        {
            //万が一、体力が負の数になった場合バーの長さを0にする
            healthBar.transform.localScale = new Vector2(0, 1);
        }

    }
}
