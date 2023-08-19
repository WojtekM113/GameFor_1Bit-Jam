using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCheckPoint : MonoBehaviour
{
    public GameObject playerToRespawn;
    public PlayerScript playerScript;
    public GameObject spawnPoint;
 
    // Update is called once per frame
    void Update()
    {
        if (playerScript.healthPoints < 0f || playerScript.healthPoints == 0f || playerScript.healthPoints == -1)
        {
            playerToRespawn.transform.position = spawnPoint.transform.position;
            
            playerScript.healthPoints = 100;
        }
    }
}
