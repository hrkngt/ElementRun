using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour {

    public GameObject shield;

	public static float Health { get; set; }
    public static ElementManager.Elements ShieldElement { get; set; }

    private MeshRenderer shieldMesh;

    Vector3 originalScale;

    private void Start()
    {
        shieldMesh = shield.transform.Find("glass").GetComponent<MeshRenderer>();

        //Store original size of the shield object
        originalScale = shield.transform.localScale;

        //Set initial element
        ShieldElement = ElementManager.Elements.FIRE;

        Health = 100;
    }

    private void Update()
    {

        //Reset static values on initial state
        if (GameStateManager.CurrentState == GameStateManager.GameStates.INITIAL)
        {
            Health = 100;

            //Starting body element is fire
            ShieldElement = ElementManager.Elements.FIRE;
        }


        if (GameStateManager.CurrentState != GameStateManager.GameStates.GAMEOVER)
            shield.transform.Rotate(0, 0, 2);

        if (Health <= 0)
        {
            //Make sure the health does not go negative
            Health = 0;

            //remove the shield on break without destroying the object
            shield.transform.localPosition += new Vector3(0, 100, 0);
        }
        

        //Change size depending on its health
        shield.transform.localScale = new Vector3(originalScale.x * (Health * 0.01f), originalScale.y * (Health * 0.01f), originalScale.z);

        //Change color depending on current element
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
