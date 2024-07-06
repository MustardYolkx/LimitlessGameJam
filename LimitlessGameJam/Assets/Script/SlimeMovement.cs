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
    private bool isFaceRight;
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
        ChangeColor(currentColorItem.redValue, currentColorItem.blueValue, currentColorItem.greenValue,1);
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
                anim.SetBool("Idle", true);
                animBase.SetBool("Idle", true);

                anim.SetBool("Walk", false);
                animBase.SetBool("Walk", false);
            }
        }
    }

    public void Flip()
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
    public void Movement()
    {
        if (canMove)
        {
            rb.AddForce(handleInput * movementSpeed, ForceMode2D.Force);
        }
        
    }

    public void ChangeColor(float red,float blue, float green,float alpha)
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

                        StartCoroutine(ChangeColor(colorItem));
                        expandEffect.SetActive(true);
                        expandEffect.GetComponent<AbsorbEffect>().ChangeColor(colorItem.redValue, colorItem.blueValue, colorItem.greenValue);
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
                        if(colorItem.countLevel ==0)
                        {
                            colorItem.ChangeColor(redValue, blueValue, greenValue, gameObject.transform.position);
                            alphaValue = 0;
                            expandEffect.SetActive(true);
                            StartCoroutine(expandEffect.GetComponent<AbsorbEffect>().Disappear());
                            hasColor = false;
                            colorItem.countLevel++;
                        }
                        else
                        {
                            if(spriteRender.color == Color.white)
                            {
                                colorItem.countLevel++;
                            }
                            else
                            {
                                colorItem.countLevel--;
                            }
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ChangeColorItem colorItem = collision.GetComponent<ChangeColorItem>();
        //if (colorItem != null)
        //{
        //    currentColorItem = colorItem;
        //    CanChangeColor= true;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //ChangeColorItem colorItem = collision.GetComponent<ChangeColorItem>();
        //if (colorItem != null)
        //{
        //    currentColorItem = null;
        //    CanChangeColor = false;
        //}
    }
}
