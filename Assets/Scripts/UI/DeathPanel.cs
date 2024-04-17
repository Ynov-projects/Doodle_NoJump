using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DeathPanel : MonoBehaviour
{
    public void OnRetryClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuitClick()
    {
            Application.Quit();
    }
}
