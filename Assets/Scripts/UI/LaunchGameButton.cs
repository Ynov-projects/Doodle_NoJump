using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGameButton : MonoBehaviour
{
    public void LaunchButton()
    {
        SceneManager.LoadScene("Didacticiel");
    }
}
