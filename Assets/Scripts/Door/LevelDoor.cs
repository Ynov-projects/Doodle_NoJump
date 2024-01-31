using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor: MonoBehaviour
{
    public string NameScene;

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(NameScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "LegPlayer")
        {
            GoToNextLevel();
        }
    }
}