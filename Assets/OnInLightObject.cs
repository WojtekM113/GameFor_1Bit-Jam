using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInLightObject : MonoBehaviour
{
    public PlayerScript playerScript;

    public bool isInLight;

  
    public float hpClamp;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
       
        hpClamp = Mathf.Clamp(playerScript.healthPoints, -1, 100);
        playerScript.healthPoints = hpClamp;
         
        if (isInLight)
        {
            playerScript.healthPoints -= 80 * Time.deltaTime;
        }
        else if (isInLight == false)
        {
            playerScript.healthPoints += 40 * Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
             Debug.Log(hpClamp);
        }

        if (playerScript.healthPoints < 0)
        {
            Debug.Log("Dead");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isInLight = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        isInLight = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isInLight = false;
        
    }
}
