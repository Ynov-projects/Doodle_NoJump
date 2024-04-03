using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    [SerializeField] private GameObject indication;

    private bool isInTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInTrigger = true;
        indication.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTrigger = false;
        indication.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInTrigger) ChangeScene();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
