using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingOptions : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    
    public void Menu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void ReRun()
    {
        PlayerPrefs.SetInt("Level", 5);
        PlayerPrefs.SetInt("Lives", 4);
        PlayerPrefs.SetInt("Time", 0);
        SceneManager.LoadScene("The Game");
    }

    public void Quit()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

}
