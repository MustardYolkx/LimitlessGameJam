using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class RestartButton : UIBase
{
    private static string sceneName;
    void Awake()
    {
        Register("RestartBtn").onClick = onRestart;
    }
    private void onRestart(GameObject obj, PointerEventData pData)
    {
        sceneName = UIManager.nowSceneName;
        //SoundManager.Instance.PlayEffect("Pause");
        SceneManager.LoadScene(sceneName);
    }

}
