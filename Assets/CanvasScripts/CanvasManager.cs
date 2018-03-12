using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

    /// <summary>
    /// ゲーム内の状況に応じてキャンバス状に表示するパネルを切り替えるためのスクリプト
    /// </summary>


    public Canvas canvas;　　//操作するキャンバス
    bool hasWaited = false;　//一定時間待ったことを確認

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

            //１秒待った後にリザルトパネルを表示する
            StartCoroutine(Wait(1.0f));
            if(hasWaited)
                SetActive("ResultPanel", true);

        }else if(GameStateManager.CurrentState == GameStateManager.GameStates.PAUSED)
        {
            DeactivateAll();
            SetActive("FaderImage", true);
            SetActive("PausedPanel", true);
        }
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
        hasWaited = true;
    }

    private void DeactivateAll() //キャンバス上のすべてのパネルを非表示にする
    {
        foreach (Transform child in canvas.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void SetActive(string name, bool toggle) //キャンバス上の名前で指定された要素を　表示/非表示に　する
    {
        //指定の名前に該当するオブジェクトを子から探し、
        foreach (Transform child in canvas.transform)
        {
            if (child.name == name)　//該当するオブジェクトを見つけた場合
            {
                ///表示 / 非表示にする
                child.gameObject.SetActive(toggle);
                
                ///完了
                return;
            }
        }

        //該当する名前のオブジェクトが見当たらない場合、コンソールに警告を表示
        Debug.LogWarning("Not found objname:" + name);
    }
}
