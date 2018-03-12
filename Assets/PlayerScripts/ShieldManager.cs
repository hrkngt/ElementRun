using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour {

    /// <summary>
    /// シールドの耐久力、属性、挙動を管理するためのスクリプト
    /// </summary>

	public static float Health { get; set; } //シールドの耐久力
    public static ElementManager.Elements ShieldElement { get; set; } //シールドの属性

    private MeshRenderer shieldMesh; //シールドの色を変更するために使用

    Vector3 originalScale; //シールドの初期サイズを格納するために使用

    private void Start()
    {
        shieldMesh = transform.Find("glass").GetComponent<MeshRenderer>();

        //シールドの初期サイズを格納
        originalScale = transform.localScale;

        //シールドの初期属性を炎(赤)にセット
        ShieldElement = ElementManager.Elements.FIRE;

        //シールドの耐久力の初期値をセット
        Health = 100;
    }

    private void Update()
    {
        //シーンリセット時にスタティック値に初期値をセット
        if (GameStateManager.CurrentState == GameStateManager.GameStates.INITIAL)
        {
            Health = 100;

            //初期属性は炎(赤)
            ShieldElement = ElementManager.Elements.FIRE;
        }

        //ゲームオーバー時以外はシールドを回転させる
        if (GameStateManager.CurrentState != GameStateManager.GameStates.GAMEOVER)
            transform.Rotate(0, 0, 2);

        //シールドの耐久値が0以下の場合
        if (Health <= 0)
        {
            //シールドの耐久力を0に設定
            Health = 0;

            //オブジェクト自体を破壊することなくゲームから除外するため、上に移動させる
            transform.localPosition += new Vector3(0, 100, 0);
        }
        

        //シールドの耐久力によってサイズを更新
        transform.localScale = new Vector3(originalScale.x * (Health * 0.01f), originalScale.y * (Health * 0.01f), originalScale.z);

        //現在の属性に応じて色を変更
        switch (ShieldElement)
        {
            case ElementManager.Elements.FIRE:
                shieldMesh.material.color = Color.red;
                break;
            case ElementManager.Elements.WATER:
                shieldMesh.material.color = Color.blue;
                break;
            case ElementManager.Elements.LEAF:
                shieldMesh.material.color = Color.green;
                break;
        }

    }

}
