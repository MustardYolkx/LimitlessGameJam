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

    public virtual IEnumerator ColorChangeEffect(float red, float blue, float green,Vector2 pos)
    {
        effectSprite.SetActive(true);
        effectSprite.GetComponent<ItemChangeEffect>().ChangeColor(red, blue, green);
        StartCoroutine(effectSprite.GetComponent<ItemChangeEffect>().Expand(pos));
        yield return new WaitForSeconds(1f);
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
                blueValue = color0.r;
                greenValue = color0.r;
            }
            if (countLevel == 1)
            {
                redValue = color1.r;
                blueValue = color1.r;
                greenValue = color1.r;
            }
            else if (countLevel == 2)
            {
                redValue = color2.r;
                blueValue = color2.r;
                greenValue = color2.r;
            }
            else if (countLevel == 3)
            {
                redValue = color3.r;
                blueValue = color3.r;
                greenValue = color3.r;
            }
        }
    }
}
