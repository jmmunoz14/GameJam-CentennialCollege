//ShockByteStudios COMP 397
//MedieWheelOfTime

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject mapUI;
    public GameObject playerCamera;
    PlayerBehaviour playerBehaviour;
    PlayerWeaponManager playerWeaponManager;
    GameObject enemies;
    public GameObject NoSaveFile;

    private void Start()
    {
        playerBehaviour=GameObject.FindObjectOfType<PlayerBehaviour>();
        playerWeaponManager = GameObject.FindObjectOfType<PlayerWeaponManager>();


    }
    public void MenuButton()
    {

        if(gamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }

    }
    //Resume the game
    void Resume()
    {
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        mapUI.SetActive(true);
        playerCamera.GetComponent<CameraController>().enabled = true;
        Time.timeScale = 1f;
        gamePaused = false;

    }

    //Pause the Game
    void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        mapUI.SetActive(false);
        playerCamera.GetComponent<CameraController>().enabled = false;
        Time.timeScale = 0f;
        NoSaveFile.SetActive(false);
        gamePaused = true;
    }

    public void OnSaveGameClicked()
    {
        List<EnemyData> enemiesData = new List<EnemyData>();
        enemies = GameObject.Find("Enemies");

        foreach (Transform enemy in enemies.transform)
        {
            Debug.Log(enemy.gameObject.GetComponent<EnemyBehavior>());
            /*
            if (enemy.gameObject.activeSelf)
            {
                EnemyBehavior tempEnemyBehavior = enemy.gameObject.GetComponent<EnemyBehavior>();
                EnemyData tempEnemyData = new EnemyData(tempEnemyBehavior);
                enemiesData.Add(tempEnemyData);
            }*/

        }
        SaveManager.SavePlayerData(playerBehaviour, playerWeaponManager, enemiesData.ToArray());
        Debug.Log("Data saved!");
    }

    public void OnLoadGameClicked()
    {
        Time.timeScale = 1f;

        MenuController.playerData = SaveManager.LoadPlayerData();
        if (MenuController.playerData == null)
        {
            NoSaveFile.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, mode: LoadSceneMode.Single);
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }
}
