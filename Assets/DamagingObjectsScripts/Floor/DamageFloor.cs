using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFloor : BaseDamager {

    /// <summary>
    /// ダメージを受けるフロアの設定をするためのスクリプト
    /// </summary>

    public ElementManager.Elements e; //フロアの属性

    private void Awake()
    {
        DamageForSameElement = 1;　//同属性に対するダメージ
        DamageForWeakElement = 1.5f;　//弱属性に対するダメージ
        SetElements(e);　//属性を設定
    }

    private void OnCollisionStay(Collision collision)
    {
        //接触時の設定
        if (collision.gameObject.name == "robotMesh")
        {
            if (PlayerManager.BodyElement == ElementSame)
                PlayerManager.Health -= DamageForSameElement;
            if (PlayerManager.BodyElement == ElementWeak)
                PlayerManager.Health -= DamageForWeakElement;
        }

    }
}
