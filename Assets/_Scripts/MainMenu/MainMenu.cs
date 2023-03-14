using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Starting Game");
        SceneManager.LoadScene("Mithul_Scene");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();

    }

    public void Menu()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene("StartMenu");
        GameManager.score = 0;
    }

 

    public void Options()
    {
        Debug.Log("OptionsMenu");
        SceneManager.LoadScene("OptionsMenu");
    }
}
