using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    /// <summary>
    /// This script is for controlling player health and body element
    /// </summary>


    public static float Health { get; set; }
    public static ElementManager.Elements BodyElement { get; set; }

    public SkinnedMeshRenderer bodyMesh;

    private void Awake()
    {
        Health = 100;
    }

    private void Update()
    {
        
        //Reset static values on initial state
        if (GameStateManager.CurrentState == GameStateManager.GameStates.INITIAL)
        {
            Health = 100;

            //Starting body element is fire
            BodyElement = ElementManager.Elements.FIRE;
        }
        

        //Changes body color depending on current element
        switch (BodyElement)
        {
            case ElementManager.Elements.FIRE:
                //Change body material color to red
                bodyMesh.material.SetColor("_Color", Color.red);
                break;
            case ElementManager.Elements.WATER:
                //Change body material color to blue
                bodyMesh.material.SetColor("_Color", Color.blue);
                break;
            case ElementManager.Elements.LEAF:
                //Change body material color to green
                bodyMesh.material.SetColor("_Color", Color.green);
                break;
        }

        if (Health <= 0)
        {
            Health = 0; 
            GameStateManager.CurrentState = GameStateManager.GameStates.GAMEOVER;
        }

    }
}
