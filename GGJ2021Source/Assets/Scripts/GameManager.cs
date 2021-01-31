using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsGamePaused;
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        IsGamePaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        IsGamePaused = true;
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        IsGamePaused = false;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log(" QUITTING GAME");
    }
}