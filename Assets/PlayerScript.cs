using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    public float speed = 10;
    float jumpForce = 20;
    private float velocity;
    float gravity = -9.81f;
    private int howManyJumps;
    [SerializeField] private Transform feet;
    [SerializeField]  float floorHeight = 0.5f;
    [SerializeField]  ContactFilter2D filter;
    private bool isGrounded;
    Collider2D[] results = new Collider2D[1];
     
 
    // Update is called once per frame
    void Update()
    {
        Debug.Log(velocity);
        PlayerJump();
        
    }
    
    void PlayerJump()
    {
        velocity += gravity * 5 * Time.deltaTime;
        
        if (Physics2D.OverlapBox(feet.position, feet.localScale,0 , filter, results) > 0 && velocity <0)
        {
            velocity = 0;
            Vector2 surface = Physics2D.ClosestPoint(transform.position, results[0]) + Vector2.up * floorHeight;
            transform.position = new Vector3(transform.position.x, surface.y, transform.position.z);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity = jumpForce;
        }
        
        float horizontalInput = Input.GetAxis("Horizontal")  * speed;
        transform.Translate(new Vector3(horizontalInput, velocity, 0) * Time.deltaTime);
    }
   
        
        
}
