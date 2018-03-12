using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManager : MonoBehaviour {

    /// <summary>
    /// 属性を管理と変更するためのスクリプト
    /// </summary>

    public enum Elements
    {
        FIRE,
        WATER,
        LEAF
    }

    //プレイヤーの体の属性を変更
    public static void ChangeBodyElement(Elements element)
    {
        PlayerManager.BodyElement = element;
    }

    //プレイヤーのシールドの属性を変更
    public static void ChangeShieldElement(Elements element)
    {
        ShieldManager.ShieldElement = element;
    }


}
