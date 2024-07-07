using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float movementSpeed;
    public float drag;
    public Vector2 handleInput;

    public float redValue;
    public float greenValue;
    public float blueValue;
    public float alphaValue;

    private float xValue;
    private float yValue;
    
    public SpriteRenderer spriteRender;

    public ChangeColorItem currentColorItem;

    public bool CanChangeColor;
    public bool canMove = true;
    public bool canFlip;
    private bool hasColor;

    public bool canMoveUp;
    public GameObject expandEffect;

    public Animator anim;
    public Animator animBase;

    public Transform detectPos;

    public LayerMask colorLayer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        //spriteRender = GetComponentInChildren<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.drag = drag;
        canFlip = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputValue();
        Movement();
        Flip();
        if (Input.GetKeyDown(KeyCode.E))
        {
            AbsorbColorDetect();
            //if(CanChangeColor)
            //{
            //if (currentColorItem.canBeAbsorb)
            //{
            //    if (!hasColor)
            //    {

            //        StartCoroutine(ChangeColor(currentColorItem));
            //        expandEffect.SetActive(true);
            //        expandEffect.GetComponent<AbsorbEffect>().ChangeColor(currentColorItem.redValue, currentColorItem.blueValue, currentColorItem.greenValue);
            //        StartCoroutine( expandEffect.GetComponent<AbsorbEffect>().Expand());
            //        hasColor = true;
            //    }
            //}
            //}
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            ChangeColorDetect();
            //if (CanChangeColor)
            //{
                //if (currentColorItem.canBeChanged)
                //{
                //    if (hasColor)
                //    {

                //        currentColorItem.ChangeColor(redValue, blueValue, greenValue);
                //        alphaValue = 0;
                //        expandEffect.SetActive(true);
                //        StartCoroutine(expandEffect.GetComponent<AbsorbEffect>().Disappear());
                //        hasColor = false;
                //        //StartCoroutine(currentColorItem.ColorChangeEffect(redValue, blueValue, greenValue));
                //    }
                //}
            //}
        }
        spriteRender.color = new Color(redValue, greenValue, blueValue,alphaValue);
        Debug.DrawRay(detectPos.position, new Vector3(0, 0, 1), Color.red);
    }
    IEnumerator ChangeColor(ChangeColorItem currentColorItem)
    {
        
        yield return new WaitForSeconds(0.15f);
        ChangeColor(currentColorItem.redValue, currentColorItem.greenValue, currentColorItem.blueValue, 1);
    }
    public void GetInputValue()
    {
        if (canMoveUp)
        {
            yValue = Input.GetAxis("Vertical");
        }
       
        xValue = Input.GetAxis("Horizontal");
        handleInput = new Vector2(xValue, yValue);
        if (handleInput != Vector2.zero)
        {
            if (anim != null)
            {
                SoundManager.Instance.PlayMove();
                anim.SetBool("Walk", true);
                animBase.SetBool("Walk", true);

                anim.SetBool("Idle", false);
                animBase.SetBool("Idle", false);
            }
        }
        if (handleInput == Vector2.zero)
        {
            if (anim != null)
            {
                SoundManager.Instance.StopMove();
                anim.SetBool("Idle", true);
                animBase.SetBool("Idle", true);

                anim.SetBool("Walk", false);
                animBase.SetBool("Walk", false);
            }
        }
    }

    public void Flip()
    {
        if (canFlip)
        {

            if (xValue < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (xValue > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
    public void Movement()
    {
        if (canMove)
        {
            rb.AddForce(handleInput * movementSpeed, ForceMode2D.Force);
        }
        
    }

    public void ChangeColor(float red,float green , float blue, float alpha)
    {
        redValue= red;
        greenValue= green;
        blueValue= blue;
        alphaValue = alpha;
    }

    public void AbsorbColorDetect()
    {
        RaycastHit2D collision = Physics2D.Raycast(detectPos.position, new Vector3(0, 0, 1), 20,colorLayer);
        if (collision.collider != null)
        {

            ChangeColorItem colorItem = collision.collider.gameObject.GetComponentInParent<ChangeColorItem>();
            if (colorItem != null)
            {
                if (colorItem.canBeAbsorb)
                {
                    //if (!hasColor)
                    //{
                    SoundManager.Instance.PlayEffect("suck");
                    if (anim != null)
                    {
                        anim.SetTrigger("Absorb");
                        animBase.SetTrigger("Absorb");
                    }
                    StartCoroutine(ChangeColor(colorItem));
                        expandEffect.SetActive(true);
                        expandEffect.GetComponent<AbsorbEffect>().ChangeColor(colorItem.redValue, colorItem.greenValue, colorItem.blueValue);
                        StartCoroutine(expandEffect.GetComponent<AbsorbEffect>().Expand());
                        hasColor = true;
                    //}
                }
            }
        }
    }

    public void ChangeColorDetect()
    {
        RaycastHit2D collision = Physics2D.Raycast(detectPos.position, new Vector3(0, 0, 1), 20, colorLayer);
        
        if (collision.collider != null)
        {
            ChangeColorItem colorItem = collision.collider.gameObject.GetComponentInChildren<ChangeColorItem>();
            if (colorItem != null)
            {
                if (colorItem.canBeChanged)
                {
                    if (hasColor)
                    {
                        SoundManager.Instance.PlayEffect("paint");
                        if (anim != null)
                        {
                            anim.SetTrigger("Change");
                            animBase.SetTrigger("Change");
                        }
                        if(colorItem.isLevel3) 
                        {
                            if (colorItem.countLevel == 3)
                            {
                                colorItem.countLevel = 0;
                                colorItem.ChangeColor(redValue, greenValue, blueValue, gameObject.transform.position);
                                alphaValue = 0;
                                expandEffect.SetActive(true);
                                StartCoroutine(expandEffect.GetComponent<AbsorbEffect>().Disappear());
                                hasColor = false;

                            }
                            else
                            {
                                if (spriteRender.color == Color.white)
                                {
                                    if (colorItem.countLevel < 3)
                                    {

                                        colorItem.countLevel++;
                                    }

                                }
                                else
                                {
                                    if (colorItem.countLevel > 0)
                                    {
                                        colorItem.countLevel--;
                                    }
                                }
                                colorItem.ChangeColor(redValue, greenValue, blueValue, gameObject.transform.position);
                                alphaValue = 0;
                                expandEffect.SetActive(true);
                                StartCoroutine(expandEffect.GetComponent<AbsorbEffect>().Disappear());
                                hasColor = false;
                            }
                        
                            
                        }
                        else
                        {
                            colorItem.ChangeColor(redValue, greenValue, blueValue, gameObject.transform.position);
                            alphaValue = 0;
                            expandEffect.SetActive(true);
                            StartCoroutine(expandEffect.GetComponent<AbsorbEffect>().Disappear());
                            hasColor = false;
                        }
                    }
                }
            }
        }
    }

}
