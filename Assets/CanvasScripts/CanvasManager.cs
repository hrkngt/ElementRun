using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

    public Canvas canvas;

    bool hasWaited = false;

    private void Update()
    {
        if (GameStateManager.CurrentState == GameStateManager.GameStates.INITIAL)
        {
            DeactivateAll();
            SetActive("FaderImage", true);
            SetActive("StartPanel", true);

        }else if (GameStateManager.CurrentState == GameStateManager.GameStates.TUTORIAL)
        {
            DeactivateAll();
            SetActive("TutorialPanel", true);

        }else if(GameStateManager.CurrentState == GameStateManager.GameStates.RUNNING)
        {
            DeactivateAll();
            SetActive("MainGamePanel", true);
        }else if(GameStateManager.CurrentState == GameStateManager.GameStates.GAMEOVER)
        {
            DeactivateAll();
            SetActive("FaderImage", true);
            //Wait and show
            StartCoroutine(Wait());
            if(hasWaited)
                SetActive("ResultPanel", true);
        }else if(GameStateManager.CurrentState == GameStateManager.GameStates.PAUSED)
        {
            DeactivateAll();
            SetActive("FaderImage", true);
            SetActive("PausedPanel", true);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        hasWaited = true;
    }

    private void DeactivateAll()
    {
        foreach (Transform child in canvas.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void SetActive(string name, bool toggle)
    {
        foreach (Transform child in canvas.transform)
        {
            if (child.name == name)
            {
                child.gameObject.SetActive(toggle);
                return;
            }
        }
        Debug.LogWarning("Not found objname:" + name);
    }
}
