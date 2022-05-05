using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    
    void Start()
    {
        PlayerPrefs.SetInt("Lives", 4);
        PlayerPrefs.SetInt("Level", 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("The Game");
        }

        if (Input.GetKeyDown("m"))
        {
            Debug.Log("Works");
            SceneManager.LoadScene("Start Screen");
        }
    }
}
