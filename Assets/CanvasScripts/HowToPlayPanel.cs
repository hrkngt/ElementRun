using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HowToPlayPanel : MonoBehaviour {

    public Button goBackButton;

    private void Start()
    {
        goBackButton.onClick.AddListener(delegate{ GameStateManager.CurrentState = GameStateManager.GameStates.INITIAL; });
    }
}
