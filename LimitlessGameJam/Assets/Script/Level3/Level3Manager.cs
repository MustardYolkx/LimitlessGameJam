using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Manager : MonoBehaviour
{
    public OutLineColorCheck outLine;
    public InnerLineColorCheck innerLine;

    public int Count;

    public GameObject slimeJump;

    public GameObject Player;

    public GameObject PlayerOriginSprite;

    public GameObject targetPos;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Count== 0)
        {
            if (outLine.isCorrect && innerLine.isCorrect)
            {
                StartCoroutine(WinThisLevel());
                Count++;
            }
        }
        
    }

    IEnumerator WinThisLevel()
    {
        yield return new WaitForSeconds(0.3f);
        Player.GetComponent<SlimeMovement>().transform.rotation = Quaternion.Euler(0, 180, 0);
        Player.GetComponent<SlimeMovement>().canMove = false;
        Player.GetComponent<SlimeMovement>().canFlip = false;
        Player.GetComponent<SlimeMovement>().anim.SetBool("Walk", true);
        Player.GetComponent<SlimeMovement>().animBase.SetBool("Walk", true);
        Player.LeanMove(targetPos.transform.position, moveSpeed);
        yield return new WaitForSeconds(moveSpeed);
        PlayerOriginSprite.SetActive(false);

        slimeJump.SetActive(true);

        
    }
}
