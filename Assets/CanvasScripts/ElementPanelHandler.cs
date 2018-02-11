using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementPanelHandler : MonoBehaviour {

    public GameObject bodyElementPanel;
    public GameObject shieldElementPanel;

    Button[] bodyButtons;
    Button[] shieldButtons;

    private void Start()
    {
        bodyButtons = bodyElementPanel.gameObject.GetComponentsInChildren<Button>();
        shieldButtons = shieldElementPanel.gameObject.GetComponentsInChildren<Button>();

        ButtonHandler();
    }

    void ButtonHandler()
    {
        bodyButtons[0].onClick.AddListener(delegate { ElementManager.ChangeBodyElement(ElementManager.Elements.FIRE); });
        bodyButtons[1].onClick.AddListener(delegate { ElementManager.ChangeBodyElement(ElementManager.Elements.WATER); });
        bodyButtons[2].onClick.AddListener(delegate { ElementManager.ChangeBodyElement(ElementManager.Elements.LEAF); });

        shieldButtons[0].onClick.AddListener(delegate { ElementManager.ChangeShieldElement(ElementManager.Elements.FIRE); });
        shieldButtons[1].onClick.AddListener(delegate { ElementManager.ChangeShieldElement(ElementManager.Elements.WATER); });
        shieldButtons[2].onClick.AddListener(delegate { ElementManager.ChangeShieldElement(ElementManager.Elements.LEAF); });

    }

}
