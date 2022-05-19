using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
   
    public void PlayGame()
    {
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Lives", 4);
        PlayerPrefs.SetInt("Time", 0);
        SceneManager.LoadScene("The Game");

    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
