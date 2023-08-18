using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonsUIMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

   public void OnStartGameClick()
    {
        SceneManager.LoadScene("FirstLevel");
    }

   public void OnExitClick()
    {
        Application.Quit();
    }
}
