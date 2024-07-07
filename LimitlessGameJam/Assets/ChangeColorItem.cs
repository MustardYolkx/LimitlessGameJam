using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorItem : MonoBehaviour
{
    public float redValue;
    public float greenValue;
    public float blueValue;

    public SpriteRenderer sprite;

    public GameObject effectSprite;
    public bool canBeChanged;
    public bool canBeAbsorb;

    public int countLevel;

    public bool isLevel3;

    public Color color0;
    public Color color1;
    public Color color2;
    public Color color3;

    public float changeTime;
    protected void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        
    }
    protected void Start()
    {
        redValue = sprite.color.r;
        greenValue = sprite.color.g;
        blueValue = sprite.color.b;
    }
    protected void Update()
    {
        sprite.color = new Color(redValue, greenValue, blueValue);
    }
    public virtual void ChangeColor(float red, float blue, float green,Vector2 pos)
    {
        //redValue = red;
        //greenValue = green;
        //blueValue = blue;
        
        StartCoroutine(ColorChangeEffect(red, blue, green,pos));
    }

    public virtual IEnumerator ColorChangeEffect(float red, float green, float blue, Vector2 pos)
    {
        effectSprite.SetActive(true);
        if (isLevel3)
        {
            if (countLevel == 0)
            {
                effectSprite.GetComponent<ItemChangeEffect>().ChangeColor(color0.r, color0.g, color0.b);                
            }
            if (countLevel == 1)
            {
                effectSprite.GetComponent<ItemChangeEffect>().ChangeColor(color1.r, color1.g, color1.b);
            }
            else if (countLevel == 2)
            {
                effectSprite.GetComponent<ItemChangeEffect>().ChangeColor(color2.r, color2.g, color2.b);
            }
            else if (countLevel == 3)
            {
                effectSprite.GetComponent<ItemChangeEffect>().ChangeColor(color3.r, color3.g, color3.b);
            }
        }
        else
        {
            effectSprite.GetComponent<ItemChangeEffect>().ChangeColor(red, green, blue);
        }
            
        StartCoroutine(effectSprite.GetComponent<ItemChangeEffect>().Expand(pos));
        yield return new WaitForSeconds(changeTime);
        if (!isLevel3)
        {
            redValue = red;
            greenValue = green;
            blueValue = blue;

        }

        else if (isLevel3)
        {
            if (countLevel == 0)
            {
                redValue = color0.r;
                blueValue = color0.b;
                greenValue = color0.g;
                
            }
            if (countLevel == 1)
            {
                redValue = color1.r;
                blueValue = color1.b;
                greenValue = color1.g;
            }
            else if (countLevel == 2)
            {
                redValue = color2.r;
                blueValue = color2.b;
                greenValue = color2.g;
            }
            else if (countLevel == 3)
            {
                redValue = color3.r;
                blueValue = color3.b;
                greenValue = color3.g;
            }
        }
    }
}
