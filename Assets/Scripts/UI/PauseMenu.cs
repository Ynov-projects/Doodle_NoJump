using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void BackToHome()
    {
        SceneManager.LoadScene("intro");
        Time.timeScale = 1;
    }

    public void BackToGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}

