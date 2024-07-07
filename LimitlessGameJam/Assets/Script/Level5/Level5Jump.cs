using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5Jump : MonoBehaviour
{
    public Color redColor;

    
    public SpriteRenderer sprite;

    public float checkRange;

    public bool isRed;

    public GameObject hightlight2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckColorRange(Color playerColor)
    {
        Vector3 colorToCheck = new Vector3(playerColor.r, playerColor.g, playerColor.b);

        Vector3 targetRedCo = new Vector3(redColor.r, redColor.g, redColor.b);
        

        if (Vector3.Distance(colorToCheck, targetRedCo) < checkRange)
        {
            ColorCorrect();
        }
        else
        {
            ColorWrong();
        }



    }

    public void ColorCorrect()
    {
        SceneManager.LoadScene("Level4_1");
    }

    public void ColorWrong()
    {
        SceneManager.LoadScene("Level4");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision!=null)
        {
            SlimeMovement slime= collision.GetComponent<SlimeMovement>();   
            if(slime!=null) 
            {
                CheckColorRange(slime.spriteRender.color);
            }
        }
    }
}
