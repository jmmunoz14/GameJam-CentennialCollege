using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGameplayScene : MonoBehaviour
{
    public void GoToGameplayScene()
    {
        Debug.Log("Moving To GamePlayScene");
        SceneManager.LoadScene(1);
    }
}
