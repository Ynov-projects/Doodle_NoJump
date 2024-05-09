using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void BackToHome() 
    {
        SceneManager.LoadScene("intro");
    }

    public void BackToGame()
    {
        pauseMenu.SetActive(false);
    }
}
