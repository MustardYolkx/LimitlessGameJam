using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChangeEffect : MonoBehaviour
{
    public Transform trans;
    public SpriteRenderer sprite;

    public float redValue;
    public float greenValue;
    public float blueValue;

    public float targetScale = 3f;
    public float changeTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Expand();
    }

    private void OnEnable()
    {

        trans.localScale = Vector3.zero;
    }
    public IEnumerator Expand(Vector2 pos)
    {
        //sprite.color = new Color(slimeScr.redValue, slimeScr.blueValue, slimeScr.blueValue);
        trans.position = pos;
        gameObject.LeanScale(new Vector2(targetScale, targetScale), changeTime);
        yield return new WaitForSeconds(changeTime);

        gameObject.SetActive(false);
    }

    public void ChangeColor(float red, float green, float blue)
    {
        redValue = red;
        greenValue = green;
        blueValue = blue;
        sprite.color = new Color(redValue, greenValue, blueValue);
    }
}
