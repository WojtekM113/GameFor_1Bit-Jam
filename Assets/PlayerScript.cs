using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider2D;
    public LayerMask layer;
    public float jumpForce;
    private float jumpPressedRememberTime;
    public float jumpHeightToCut;
    private float horizontalInput;
    public float maxSpeed;
 
    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded();

   
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     rightButtonPressed = 0.2f;
        // }
        // if (Input.GetKeyDown(KeyCode.D))
        // {
        //     leftButtonPressed = 0.2f;
        // }
      

      
        
        jumpPressedRememberTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressedRememberTime = 0.2f;
        }

        if (Input.GetKeyUp(KeyCode.Space) && rigidbody.velocity.y > 0)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * jumpHeightToCut);
        }
    }

    private void FixedUpdate()
    {
        
        
        if ((jumpPressedRememberTime > 0) && isGrounded())
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }

        // if (rightButtonPressed > 0)
        // {
        //     rigidbody.AddForce(new Vector3(10,0,0), ForceMode2D.Impulse);
        //
        // }
        //
        // if (leftButtonPressed > 0)
        // {
        //     rigidbody.AddForce(new Vector3(-10, 0, 0), ForceMode2D.Impulse);
        //     
        // }

        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
        }
    }
    
    
    
    
    
    
    
    
    
    
    private bool isGrounded()
    {
        float extraHightTest = 0.1f;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down,
            boxCollider2D.bounds.extents.y + extraHightTest, layer);
        
        if (raycastHit2D.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
 

