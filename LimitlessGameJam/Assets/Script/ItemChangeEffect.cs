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
    public IEnumerator Expand()
    {
        //sprite.color = new Color(slimeScr.redValue, slimeScr.blueValue, slimeScr.blueValue);

        gameObject.LeanScale(new Vector2(3, 3), 0.2f);
        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);
    }

    public void ChangeColor(float red, float blue, float green)
    {
        redValue = red;
        greenValue = green;
        blueValue = blue;
        sprite.color = new Color(redValue, greenValue, blueValue);
    }
}
