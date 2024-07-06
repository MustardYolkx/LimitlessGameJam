using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButton : UIBase
{
    void Awake()
    {
        Register("ExitBtn").onClick = onExit;
    }

    private void onExit(GameObject obj, PointerEventData pData)
    {
        //SoundManager.Instance.PlayEffect("Pause");
        Application.Quit();
    }
}
