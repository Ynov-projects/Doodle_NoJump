using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class SwitchLevel : MonoBehaviour
{
    [SerializeField] private GameObject indication;

    private bool isInTrigger;

    private PlayerInput input;

    private void Awake()
    {
        input = new PlayerInput();
        GameManager.input.Gameplay.Enable();
    }

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
        if (GameManager.input.Gameplay.Interact.triggered && isInTrigger) ChangeScene();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
