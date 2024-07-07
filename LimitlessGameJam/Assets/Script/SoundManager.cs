using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public static AudioSource EffectSource;
    public static AudioSource MoveSource;

    private bool isOnMove = false;
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
            EffectSource = gameObject.AddComponent<AudioSource>();
            //EffectSource.volume /= 5;
            MoveSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayEffect(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/Effects/" + name);
        if (clip == null)
        {
            Debug.LogError("no sound：" + name);
            return;
        }
        EffectSource.clip = clip;
        EffectSource.Play();
    }
    public void PlayMove()
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/Effects/move");
        if (clip == null)
        {
            Debug.LogError("no sound：" + name);
            return;
        }
        MoveSource.clip = clip;
        if (!isOnMove)
        {
            isOnMove = true;
            MoveSource.Play();
        }
        MoveSource.loop = true;
    }

    public void StopMove()
    {
        isOnMove = false;
        MoveSource.loop = false;
    }
}
