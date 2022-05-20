using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject song1;
    public GameObject song2;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        if (Random.Range(0, 2) == 0)
        {
            song1.SetActive(true);
        }

        else
        {
            song2.SetActive(true);
        }
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
