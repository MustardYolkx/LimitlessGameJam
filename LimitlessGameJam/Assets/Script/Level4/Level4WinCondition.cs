using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Level4WinCondition : MonoBehaviour
{
    public Color targetColor;
    public SpriteRenderer sprite;

    public float checkRange;

    public GameObject endAnim;
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
            StartCoroutine(WinThisLevel());
        }
    }

    IEnumerator WinThisLevel()
    {

        yield return new WaitForSeconds(2.5f);
        //Play Anim
        Debug.Log("Win");

    }
}
