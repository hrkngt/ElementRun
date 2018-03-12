using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    /// <summary>
    /// プレイヤーの体の属性、及び体力を更新するためのスクリプト
    /// </summary>


    public static float Health { get; set; } //プレイヤーの体力
    public static ElementManager.Elements BodyElement { get; set; } //体の属性

    SkinnedMeshRenderer bodyMesh; //体の色を属性に応じて変更するために使用

    private void Awake()
    {
        bodyMesh = transform.Find("robotMesh").GetComponent<SkinnedMeshRenderer>();

        Health = 100; //ゲーム開始時の体力の初期値
    }

    private void Update()
    {
        
        //シーンリセット時に体力の初期値と初期の属性を再セット
        if (GameStateManager.CurrentState == GameStateManager.GameStates.INITIAL)
        {
            Health = 100;

            //初期の属性を炎(赤)にセット
            BodyElement = ElementManager.Elements.FIRE;
        }
        

        //体の色を現属性に応じて変更
        switch (BodyElement)
        {
            case ElementManager.Elements.FIRE:
                //赤に変更
                bodyMesh.material.SetColor("_Color", Color.red);
                break;

            case ElementManager.Elements.WATER:
                //青に変更
                bodyMesh.material.SetColor("_Color", Color.blue);
                break;

            case ElementManager.Elements.LEAF:
                //緑に変更
                bodyMesh.material.SetColor("_Color", Color.green);
                break;
        }

        //体力が0以下になった際に、ゲームの状態を更新
        if (Health <= 0)
        {
            //体力が負の数になった場合、0にセット
            Health = 0; 

            //ゲームの状態を”ゲームオーバー”に変更
            GameStateManager.CurrentState = GameStateManager.GameStates.GAMEOVER;
        }

    }
}
