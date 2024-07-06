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
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        
    }
    void Start()
    {
        redValue = sprite.color.r;
        greenValue = sprite.color.g;
        blueValue = sprite.color.b;
    }
    void Update()
    {
        sprite.color = new Color(redValue, greenValue, blueValue);
    }
    public void ChangeColor(float red, float blue, float green)
    {
        //redValue = red;
        //greenValue = green;
        //blueValue = blue;
        StartCoroutine(ColorChangeEffect(red, blue, green));
    }

    public IEnumerator ColorChangeEffect(float red, float blue, float green)
    {
        StartCoroutine(effectSprite.GetComponent<ItemChangeEffect>().Expand());
        yield return new WaitForSeconds(0.2f);
        redValue = red;
        greenValue = green;
        blueValue = blue;
    }
}
