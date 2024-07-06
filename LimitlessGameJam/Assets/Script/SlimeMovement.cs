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

    public SpriteRenderer spriteRender;

    public ChangeColorItem currentColorItem;

    public bool CanChangeColor;
    public bool canMove = true;
    public GameObject expandEffect;
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
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(CanChangeColor)
            {
                StartCoroutine(ChangeColor(currentColorItem));
                expandEffect.SetActive(true);
                expandEffect.GetComponent<AbsorbEffect>().ChangeColor(currentColorItem.redValue, currentColorItem.blueValue, currentColorItem.greenValue);
                StartCoroutine( expandEffect.GetComponent<AbsorbEffect>().Expand());
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (CanChangeColor)
            {
                currentColorItem.ChangeColor(redValue, blueValue, greenValue);
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
        handleInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
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
