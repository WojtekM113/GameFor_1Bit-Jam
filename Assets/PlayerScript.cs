using System;
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
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && howManyJumps < 1)
        {
            velocity = jumpForce;
            howManyJumps++;
            
        
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Debug.Log(velocity);

        velocity += gravity * 5 * Time.deltaTime;

        
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.8f) && velocity <0 )
        {
            velocity = 0;
            howManyJumps = 0;
        }
       

        float horizontalInput = Input.GetAxis("Horizontal")  * speed;
        transform.Translate(new Vector3(horizontalInput, velocity, 0) * Time.deltaTime);

 
    }

  
}
