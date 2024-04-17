using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TriggerableButton : MonoBehaviour
{
    [SerializeField] private UnityEvent action;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            action.Invoke();
    }

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void openLink(string link)
    {
        Application.OpenURL(link);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
