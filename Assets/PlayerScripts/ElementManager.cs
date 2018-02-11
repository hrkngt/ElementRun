using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManager : MonoBehaviour {

    public enum Elements
    {
        FIRE,
        WATER,
        LEAF
    }

    public static void ChangeBodyElement(Elements element)
    {
        PlayerManager.BodyElement = element;
    }

    public static void ChangeShieldElement(Elements element)
    {
        ShieldManager.ShieldElement = element;
    }


}
