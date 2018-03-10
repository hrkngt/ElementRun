using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseDamager {

    MeshRenderer meshRenderer;
    ElementManager.Elements e;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        DamageForSameElement = 40;
        DamageForWeakElement = 60;

        e = (ElementManager.Elements)Random.Range(0, 3);

        //Randomly set element
        SetElements(e);
    }

    private void Start()
    {
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
        switch (collision.gameObject.name)
        {
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

            case "robotMesh":
                if (PlayerManager.BodyElement != ElementSame && PlayerManager.BodyElement != ElementWeak)
                {   
                    //Strong element
                    PlayerManager.Health -= DamageForSameElement * 2;
                }
                else
                {
                    PlayerManager.Health = 0;
                }
                break;
        }

        Destroy(this.gameObject);
    }

}
