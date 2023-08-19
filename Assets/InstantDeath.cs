using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDeath : MonoBehaviour
{
    public PlayerScript playerScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerScript.healthPoints = playerScript.healthPoints - 10000000;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        playerScript.healthPoints = playerScript.healthPoints - 10000000;
    }

}
