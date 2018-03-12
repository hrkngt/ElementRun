using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseDamager {

    /// <summary>
    /// 障害物オブジェクト(敵)の設定をするためのスクリプト
    /// </summary>

    MeshRenderer meshRenderer; //属性に応じて色を設定するために使用
    ElementManager.Elements e; //属性を設定するために使用

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        DamageForSameElement = 40; //同属性に対するダメージ
        DamageForWeakElement = 60; //弱点促成に対するダメージ

        //ランダムに属性を決定
        e = (ElementManager.Elements)Random.Range(0, 3); 

        //属性の設定
        SetElements(e);
    }

    private void Start()
    {
        //属性に応じて色を設定
        switch (e)
        {
            case ElementManager.Elements.FIRE:
                meshRenderer.material.color = Color.red;
                break;
            case ElementManager.Elements.WATER:
                meshRenderer.material.color = Color.blue;
                break;
            case ElementManager.Elements.LEAF:
                meshRenderer.material.color = Color.green;
                break;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        //接触時の設定
        switch (collision.gameObject.name)
        {
            //シールドに接触した場合
            case "glass":
                if (ShieldManager.ShieldElement == ElementSame)
                {
                    ShieldManager.Health -= DamageForSameElement;
                }
                if (ShieldManager.ShieldElement == ElementWeak)
                {
                    ShieldManager.Health -= DamageForWeakElement;
                }
                break;

            //プレイヤー自体に接触した場合
            case "robotMesh":
                //プレイヤー自体に属性が敵に対して強い物であった場合
                if (PlayerManager.BodyElement != ElementSame && PlayerManager.BodyElement != ElementWeak)
                {   
                    PlayerManager.Health -= DamageForSameElement * 2;
                }
                else
                {
                    //ゲームオーバー
                    PlayerManager.Health = 0;
                }
                break;
        }

        //ぶつかった敵オブジェクトを消す
        Destroy(this.gameObject);
    }

}
