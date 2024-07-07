using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class AbsorbEffect : MonoBehaviour
{
    public SlimeMovement slimeScr;
    public Transform trans;
    public SpriteRenderer sprite;

    public float redValue;
    public float greenValue;
    public float blueValue;

    public float targetScale = 3f;
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

        
    }
    public IEnumerator Expand()
    {
        
        //sprite.color = new Color(slimeScr.redValue, slimeScr.blueValue, slimeScr.blueValue);
        trans.localScale = Vector3.zero;
        gameObject.LeanScale(new Vector2(targetScale, targetScale), 0.2f);
        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);
    }
    public IEnumerator Disappear()
    {
        trans.localScale = new Vector3(targetScale, targetScale);
        gameObject.LeanScale(new Vector2(0, 0), 0.2f);
        yield return new WaitForSeconds(0.2f);

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
