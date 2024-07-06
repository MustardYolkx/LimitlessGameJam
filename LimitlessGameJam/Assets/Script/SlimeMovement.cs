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
            if(CanChangeColor)
            {
                if (currentColorItem.canBeAbsorb)
                {
                    if (!hasColor)
                    {
                        SoundManager.Instance.PlayEffect("suck");
                        StartCoroutine(ChangeColor(currentColorItem));
                        expandEffect.SetActive(true);
                        expandEffect.GetComponent<AbsorbEffect>().ChangeColor(currentColorItem.redValue, currentColorItem.blueValue, currentColorItem.greenValue);
                        StartCoroutine( expandEffect.GetComponent<AbsorbEffect>().Expand());
                        hasColor = true;
                    }
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (CanChangeColor)
            {
                if (currentColorItem.canBeChanged)
                {
                    if (hasColor)
                    {
                        SoundManager.Instance.PlayEffect("paint");
                        currentColorItem.ChangeColor(redValue, blueValue, greenValue);
                        alphaValue = 0;
                        expandEffect.SetActive(true);
                        StartCoroutine(expandEffect.GetComponent<AbsorbEffect>().Disappear());
                        hasColor = false;
                        //StartCoroutine(currentColorItem.ColorChangeEffect(redValue, blueValue, greenValue));
                    }
                }
            }
        }
        spriteRender.color = new Color(redValue, greenValue, blueValue,alphaValue);
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
            SoundManager.Instance.PlayMove();
            anim.SetBool("Walk", true);
            animBase.SetBool("Walk", true);

            anim.SetBool("Idle", false);
            animBase.SetBool("Idle", false);
        }
        if (handleInput == Vector2.zero)
        {
            SoundManager.Instance.StopMove();
            anim.SetBool("Idle", true);
            animBase.SetBool("Idle", true);

            anim.SetBool("Walk", false);
            animBase.SetBool("Walk", false);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeColorItem colorItem = collision.GetComponent<ChangeColorItem>();
        if (colorItem != null)
        {
            currentColorItem = colorItem;
            CanChangeColor= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ChangeColorItem colorItem = collision.GetComponent<ChangeColorItem>();
        if (colorItem != null)
        {
            currentColorItem = null;
            CanChangeColor = false;
        }
    }
}
