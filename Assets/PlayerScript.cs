using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
 
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider2D;
    public LayerMask layer;
    public float jumpForce;
    private float jumpPressedRememberTime;
    private Vector2 horizontalInput;
    public float linearDrag;
    private float isGroundedTime;
    private bool isSpacePressed = false;
    public float downWardsForce;
    private float horizontalVelocity;
    public float maxSpeed;
    private int spacePressedNumber;

    public float healthPoints;

    public Slider slider;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();

        _spriteRenderer = GetComponent<SpriteRenderer>();


    }
    
    

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isGroundedTime);
        UpdateProgress();
        isGrounded();
        isGroundedTime -= Time.deltaTime;
        
        if (isGrounded())
        {
            isGroundedTime = 0.15f;
        }
        else
        {
            isGroundedTime = isGroundedTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        if (Input.GetKeyUp(KeyCode.Space) && rigidbody.velocity.y > 0)
        {
            isSpacePressed = false;
        }
        
        jumpPressedRememberTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpacePressed = true;
            jumpPressedRememberTime = 0.2f;
            
        }
        
       
        horizontalVelocity = Input.GetAxisRaw("Horizontal");

       
         
    }
    
    private void FixedUpdate()
    {
        
        Jump();

        if (rigidbody.velocity.y > 0 && isSpacePressed == false)
        {
            rigidbody.velocity = new Vector2( rigidbody.velocity.x, downWardsForce);
            
        }
        else
        {
            rigidbody.velocity =  new Vector2(rigidbody.velocity.x,rigidbody.velocity.y);
        }
        
     
        CharacterMovement(horizontalVelocity);
        ModifyPhysics();
      
       
       
    }

    void CharacterMovement(float PlayerInputHorizontal)
    {
        rigidbody.AddForce(Vector2.right * PlayerInputHorizontal * speed, ForceMode2D.Force);
        
        
        if ((Mathf.Abs(rigidbody.velocity.x) )    > maxSpeed)
        {
            rigidbody.velocity = new Vector2(Mathf.Sign(rigidbody.velocity.x) * maxSpeed  , rigidbody.velocity.y);
        }
        
      
        
    }

    void ModifyPhysics()
    {
        if (isGrounded())
        {
            if (Mathf.Abs(horizontalVelocity) < 0.4f)
            {
                rigidbody.drag = linearDrag;
            }
            else
            {
                rigidbody.drag = 0;
            }

            rigidbody.gravityScale = 0;
        }
        else
        {
            rigidbody.gravityScale = 20;
            rigidbody.drag = 0;
        }




    }

    void Jump()
    {

        if ((jumpPressedRememberTime > 0) && (isGroundedTime > 0) && (isSpacePressed == true))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            
        }
    

    }

    
    
    private bool isGrounded()
    {
         
        float extraHightTest = 0.1f;

        RaycastHit2D raycastHit2D =
            Physics2D.BoxCast(boxCollider2D.bounds.center, transform.localScale, 0, Vector2.down,4f,layer);
        // RaycastHit2D raycastHit2D = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down,
        //     boxCollider2D.bounds.extents.y + extraHightTest, layer);
             
        
        if (raycastHit2D.collider != null)
        {
            return true;
            
        }
        else
        {
            return false;
        }
    }

    void UpdateProgress()
    {
        slider.value = healthPoints;
    }
}
 

