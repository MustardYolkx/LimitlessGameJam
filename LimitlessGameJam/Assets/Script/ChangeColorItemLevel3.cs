using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorItemLevel3 :ChangeColorItem
{
    public Color color0;
    public Color color1;
    public Color color2;
    public Color color3;
    private new void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    private new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if(sprite.color == color1)
        {
            countLevel = 1;
        }
        else if(sprite.color == color2)
        {
            countLevel = 2;
        }
        else if(sprite.color == color3)
        {
            countLevel = 3;
        }
    }

    public override void ChangeColor(float red, float blue, float green, Vector2 pos)
    {
        StartCoroutine(ColorChangeEffect(red, blue, green, pos));
    }

    public override IEnumerator ColorChangeEffect(float red, float blue, float green, Vector2 pos)
    {
        effectSprite.SetActive(true);
        effectSprite.GetComponent<ItemChangeEffect>().ChangeColor(red, blue, green);
        StartCoroutine(effectSprite.GetComponent<ItemChangeEffect>().Expand(pos));
        yield return new WaitForSeconds(1f);
        if (countLevel == 0)
        {
            redValue = color0.r;
            blueValue = color0.r;
            greenValue = color0.r;
        }
        if (countLevel== 1)
        {
            redValue = color1.r;
            blueValue = color1.r;
            greenValue = color1.r;
        }
        else if(countLevel == 2)
        {
            redValue = color2.r;
            blueValue = color2.r;
            greenValue = color2.r;
        }
        else if(countLevel == 3)
        {
            redValue = color3.r;
            blueValue = color3.r;
            greenValue = color3.r;
        }

    }
}
