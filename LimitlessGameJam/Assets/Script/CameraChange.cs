using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCamara(int priority)
    {
        //transform.position = targetPos;
        cam.Priority= priority;
    }
}
