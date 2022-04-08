using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    
    void Start()
    {
        PlayerPrefs.SetInt("Lives", 4);
        PlayerPrefs.DeleteKey("Level");
        PlayerPrefs.DeleteKey("Area");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("The Game");
        }
    }
}
