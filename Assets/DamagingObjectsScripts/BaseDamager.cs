using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamager : MonoBehaviour {

    public ElementManager.Elements ElementSame { get; set; }
    public ElementManager.Elements ElementWeak { get; set; }

    public float DamageForSameElement { get; set; }
    public float DamageForWeakElement { get; set; }


    public void SetElements(ElementManager.Elements element)
    {

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
