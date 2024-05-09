using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelDoor: MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip clip;
    [SerializeField] private GameObject indication;

    private bool isInTrigger;

    private void DesactivateLevels()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Level")) go.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.input.Gameplay.Interact.triggered && isInTrigger)
        {
            PlayerMovement.instance.StopPlayer();
            animator.SetBool("readyToMove", true);
            currentSceneManager.instance.canTeleport = false;
            AudioManager.Instance.PlayClip(clip);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            indication.SetActive(true);
            isInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            indication.SetActive(false);
            isInTrigger = false;
        }
    }

    public void EndOfLevel()
    {
        animator.SetBool("readyToMove", false);
        PlayerMovement.instance.gameObject.transform.position = Vector3.zero;
        currentSceneManager.instance.spawnPoint = Vector3.zero;
        PlayerMovement.instance.enabled = true;
        currentSceneManager.instance.canTeleport = true;
        DesactivateLevels();
    }
}