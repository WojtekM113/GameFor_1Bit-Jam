using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTriggers : MonoBehaviour
{
    public OnInLightObject OnInLightObject;

    public Collider2D OnInLightColliders;

    public PlayerScript PlayerScript;
    // Start is called before the first frame update

    private void Awake()
    {
        OnInLightObject.enabled = false;
    }

    void Start()
    {
        OnInLightColliders = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnInLightObject.enabled = false;
        PlayerScript.healthPoints += 40 * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        OnInLightObject.enabled = false;
        PlayerScript.healthPoints += 40 * Time.deltaTime;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        OnInLightObject.enabled = true;
    }
}
