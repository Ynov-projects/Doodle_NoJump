using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPanel : MonoBehaviour
{
    [SerializeField] private Transform player;

    //public void OnRetryClick()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    public void OnQuitClick()
    {
        Application.Quit();
    }
}
