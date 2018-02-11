using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFloor : BaseDamager {

    public ElementManager.Elements e;

    private void Awake()
    {
        DamageForSameElement = 1;
        DamageForWeakElement = 1.5f;
        SetElements(e);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "robotMesh")
        {
            if (PlayerManager.BodyElement == ElementSame)
                PlayerManager.Health -= DamageForSameElement;
            if (PlayerManager.BodyElement == ElementWeak)
                PlayerManager.Health -= DamageForWeakElement;
        }

    }
}
