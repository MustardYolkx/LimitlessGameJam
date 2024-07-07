using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : UIBase
{
    void Awake()
    {
        Register("StartBtn").onClick = onBack;
    }

    private void onBack(GameObject obj, PointerEventData pData)
    {
        SceneManager.LoadScene("Level1");
    }
}
