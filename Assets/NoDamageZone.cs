using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDamageZone : MonoBehaviour
{
   public PlayerScript playerScript;
   public OnInLightObject OnInLightObject;

  

   private void OnTriggerEnter2D(Collider2D other)
   {
      OnInLightObject.isInLight = false;
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      OnInLightObject.isInLight = true;
   }
}
