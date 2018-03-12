using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamager : MonoBehaviour {

    /// <summary>
    /// プレイヤーにダメージを与えるオブジェクトの設定をするためのスクリプト
    /// </summary>


    public ElementManager.Elements ElementSame { get; set; }　//同属性
    public ElementManager.Elements ElementWeak { get; set; }　//弱点属性

    public float DamageForSameElement { get; set; }　//同属性に対するダメージ
    public float DamageForWeakElement { get; set; }　//弱点属性に対するダメージ


    public void SetElements(ElementManager.Elements element)　//属性を設定
    {
        //属性に応じて同属性と弱点属性を設定
        switch (element)
        {
            case ElementManager.Elements.FIRE:
                ElementSame = ElementManager.Elements.FIRE;
                ElementWeak = ElementManager.Elements.LEAF;
                break;

            case ElementManager.Elements.WATER:
                ElementSame = ElementManager.Elements.WATER;
                ElementWeak = ElementManager.Elements.FIRE;
                break;

            case ElementManager.Elements.LEAF:
                ElementSame = ElementManager.Elements.LEAF;
                ElementWeak = ElementManager.Elements.WATER;
                break;
        }
    }

}
