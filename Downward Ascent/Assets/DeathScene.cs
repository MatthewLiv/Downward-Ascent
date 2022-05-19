using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        PlayerPrefs.SetInt("Lives", 4);
        PlayerPrefs.SetInt("Level", 4);
        
    }

    public void menU()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void Rerun()
    {
        PlayerPrefs.SetInt("Time", 0);
        SceneManager.LoadScene("The Game");
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

}
