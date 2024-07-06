using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackButton : UIBase
{
    // Start is called before the first frame update
    void Awake()
    {
        Register("BackBtn").onClick = onBack;
    }

    private void onBack(GameObject obj, PointerEventData pData)
    {
        //SoundManager.Instance.PlayEffect("Pause");
        UIManager.Instance.GetUI<PauseButton>("PauseButton").isOpen = false;
        UIManager.Instance.CloseUI("ExitButton");
        UIManager.Instance.CloseUI("RestartButton");
        UIManager.Instance.CloseUI("BackButton");
    }
}
