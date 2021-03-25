using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }
    #endregion
    public static bool IsGamePaused;
    [SerializeField] private GameObject pauseMenu;

    private void Start() => IsGamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            LoadMainScene();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused) ResumeGame();
            else PauseGame();
        }
    }

    public void CursorOff()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CursorOn()
    {
        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }

    public void PauseGame()
    {
        IsGamePaused = true;
        Time.timeScale = 0.0f;
        CursorOn();
        if(pauseMenu)
            pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        IsGamePaused = false;
        Time.timeScale = 1.0f;
        CursorOff();
        if(pauseMenu)
            pauseMenu.SetActive(false);
    }

    public void QuitGame() => Application.Quit();

    public void RespawnAt(Transform spawnPoint)
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = spawnPoint.position;
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadEndScene(){
        SceneManager.LoadScene("EndGameScene");
    }
}