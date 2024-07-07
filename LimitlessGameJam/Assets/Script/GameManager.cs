using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(Instance);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.Init();
        var bgm = gameObject.AddComponent<AudioSource>();
        bgm.clip = Resources.Load<AudioClip>("Sounds/BGM/BGM");
        bgm.loop = true;
        bgm.Play();
        if (UIManager.nowSceneName != "Start")
        {
            UIManager.Instance.ShowUI<PauseButton>("PauseButton");
        }
        else
        {
            UIManager.Instance.ShowUI<StartButton>("StartButton");
        }

    }

}
