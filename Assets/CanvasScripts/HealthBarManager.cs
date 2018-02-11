using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour {

    public Image healthBar; //Image which shrinks depending on player health
    float maxHealth;        //used to store the maximum health value

    private void Start()
    {
        maxHealth = PlayerManager.Health; //store max health
    }


    private void Update()
    {

        if (PlayerManager.Health > 0)
        {
            //shrink depending on player health
            healthBar.transform.localScale = new Vector2(PlayerManager.Health / maxHealth, 1);
        }
        else 
        {
            //Ensure the healthbar does not go negative
            healthBar.transform.localScale = new Vector2(0, 1);
        }

    }
}
