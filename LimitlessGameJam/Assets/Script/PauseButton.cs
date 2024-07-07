using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : UIBase
{
    public bool isOpen = false;
    // Start is called before the first frame update
    void Awake()
    {
        Register("PauseBtn").onPointerEnter = onZoom;
        Register("PauseBtn").onClick = openMenu;
    }

    void openMenu(GameObject obj, PointerEventData pData)
    {

        if (!isOpen)
        {
            UIManager.Instance.ShowUI<BackButton>("BackButton");
            UIManager.Instance.ShowUI<ExitButton>("ExitButton");
            UIManager.Instance.ShowUI<RestartButton>("RestartButton");
            isOpen = true;
        }
        else
        {
            UIManager.Instance.CloseUI("BackButton");
            UIManager.Instance.CloseUI("ExitButton");
            UIManager.Instance.CloseUI("RestartButton");
            isOpen = false;
        }
    }

    void onZoom(GameObject obj, PointerEventData pData)
    {
        Debug.Log(111);
    }

}
