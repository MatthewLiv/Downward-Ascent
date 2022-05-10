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
        PlayerPrefs.SetInt("Level", 5);
        PlayerPrefs.SetInt("Lives", 4);
        SceneManager.LoadScene("The Game");

    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
