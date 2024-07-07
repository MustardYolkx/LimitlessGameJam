using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InnerLineColorCheck : MonoBehaviour
{
    public Color targetColor;
    public SpriteRenderer sprite;

    public float checkRange;

    public bool isCorrect;
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

        Vector3 targetCo = new Vector3(targetColor.r, targetColor.g, targetColor.b);
        if (Vector3.Distance(colorToCheck, targetCo) < checkRange)
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
        isCorrect = true;
    }

    public void ColorWrong()
    {
        isCorrect = false;
    }
}
