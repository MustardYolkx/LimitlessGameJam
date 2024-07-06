using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    public static BgmManager Instance;
    private AudioSource bgmSource;
    // Start is called before the first frame update
    void Awake()
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
    public void Init()
    {
        if (gameObject.GetComponent<AudioSource>() == null)
        {
            bgmSource = gameObject.AddComponent<AudioSource>();
            //bgmSource.volume /= 3;
        }
    }
    public void PlayBGM(string name, bool isLoop = true)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/BGM/" + name);

        if (clip == null)
        {
            Debug.LogError("√ª”–¥À“Ù∆µ£∫" + name);
            return;
        }

        bgmSource.clip = clip;

        bgmSource.loop = isLoop;

        bgmSource.Play();
    }
    public void BGMPlayPause()
    {
        bgmSource.Pause();
    }

    public void BGMPlayContinue()
    {
        bgmSource.Play();
    }

    public void BGMPlayStop()
    {
        bgmSource.Stop();
    }
}
