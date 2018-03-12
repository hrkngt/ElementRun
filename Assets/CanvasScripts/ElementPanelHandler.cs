using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementPanelHandler : MonoBehaviour {

    /// <summary>
    /// 属性変更ボタンの設定をするためのスクリプト
    /// </summary>

    public GameObject bodyElementPanel;　　//プレイヤーの体の属性を変更するパネル
    public GameObject shieldElementPanel;　//シールドの属性を変更するパネル

    Button[] bodyButtons;　　//体の属性を変更するボタン
    Button[] shieldButtons;　//シールドの属性を変更するボタン

    private void Start()
    {
        bodyButtons = bodyElementPanel.gameObject.GetComponentsInChildren<Button>();
        shieldButtons = shieldElementPanel.gameObject.GetComponentsInChildren<Button>();

        ButtonHandler();
    }


    //ボタンが押された際の挙動の設定
    void ButtonHandler()
    {
        //各ボタンが押された際に体の属性を変更
        bodyButtons[0].onClick.AddListener(delegate { ElementManager.ChangeBodyElement(ElementManager.Elements.FIRE); });
        bodyButtons[1].onClick.AddListener(delegate { ElementManager.ChangeBodyElement(ElementManager.Elements.WATER); });
        bodyButtons[2].onClick.AddListener(delegate { ElementManager.ChangeBodyElement(ElementManager.Elements.LEAF); });

        //各ボタンが押された際にシールドの属性を変更
        shieldButtons[0].onClick.AddListener(delegate { ElementManager.ChangeShieldElement(ElementManager.Elements.FIRE); });
        shieldButtons[1].onClick.AddListener(delegate { ElementManager.ChangeShieldElement(ElementManager.Elements.WATER); });
        shieldButtons[2].onClick.AddListener(delegate { ElementManager.ChangeShieldElement(ElementManager.Elements.LEAF); });

    }

}
