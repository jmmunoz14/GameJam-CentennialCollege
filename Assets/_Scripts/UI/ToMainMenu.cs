using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    public void GotToMainMenu()
    {
        Debug.Log("Moving To Main Menu");
        SceneManager.LoadScene(0);
    }
}

