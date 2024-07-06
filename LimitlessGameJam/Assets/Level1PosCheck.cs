using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1PosCheck : MonoBehaviour
{

    public float red;
    public float green;
    public float blue;

    public GameObject targetPos;

    public GameObject currentCamera;
    public GameObject targetCamera;

    public SlimeMovement slime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(slime != null)
        {
            if (red == slime.redValue && green == slime.greenValue && blue == slime.blueValue)
            {
                if (Vector2.Distance(slime.transform.position, targetPos.transform.position) < 2f)
                {
                    currentCamera.GetComponent<CameraChange>().ChangeCamara(3);

                    slime.transform.position = targetPos.transform.position;
                    slime.canMove = false;

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       slime = collision.GetComponent<SlimeMovement>();
        if (slime != null)
        {
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        slime = collision.GetComponent<SlimeMovement>();
        if (slime != null)
        {
            slime = null;
        }
    }
}
