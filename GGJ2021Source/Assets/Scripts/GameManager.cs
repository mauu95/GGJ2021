using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsGamePaused;
    [SerializeField] private GameObject pauseMenu;

    private void Start() => IsGamePaused = false;

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
        pauseMenu.SetActive(true);
        CursorOn();
    }

    public void ResumeGame()
    {
        IsGamePaused = false;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        CursorOff();
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
}