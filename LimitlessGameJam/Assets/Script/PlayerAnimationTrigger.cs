using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimationTrigger : MonoBehaviour
{
    SlimeMovement slimeScr;
    // Start is called before the first frame update
    private void Awake()
    {
        slimeScr = GetComponentInParent<SlimeMovement>();
    }
    public void DisableMove()
    {
        slimeScr.canMove = false;
    }

    public void EnableMove()
    {
        slimeScr.canMove = true;
    }

    public void TurnToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
