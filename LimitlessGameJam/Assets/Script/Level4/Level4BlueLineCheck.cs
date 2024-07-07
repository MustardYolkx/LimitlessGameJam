using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4BlueLineCheck : MonoBehaviour
{
    public Color redColor;

    public Color blueColor;
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
        CheckColorRange();
    }

    public void CheckColorRange()
    {
        Vector3 colorToCheck = new Vector3(sprite.color.r, sprite.color.g, sprite.color.b);

        Vector3 targetRedCo = new Vector3(redColor.r, redColor.g, redColor.b);
        Vector3 targetBlueCo = new Vector3(blueColor.r, blueColor.g, blueColor.b);

        if (Vector3.Distance(colorToCheck, targetRedCo) < checkRange)
        {
            RedColorCorrect();
        }
        else
        {
            RedColorWrong();
        }

        if (Vector3.Distance(colorToCheck, targetBlueCo) < checkRange)
        {
            //RedColorCorrect();
        }
        else
        {
            //RedColorWrong();
        }

    }

    public void RedColorCorrect()
    {
        isRed = true;
        hightlight2.SetActive(true);
    }

    public void RedColorWrong()
    {
        isRed = false;
        hightlight2.SetActive(false);
    }

    public void BlueColorCorrect()
    {
        isRed = true;
    }

    public void BlueColorWrong()
    {
        isRed = false;
    }
}
