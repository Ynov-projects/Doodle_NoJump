using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class TeleportMe : MonoBehaviour
{
    [SerializeField] private GameObject teleportPosition;

    private bool isInTeleporter;

    private GameObject toTeleport;
    [SerializeField] private GameObject indication;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject level;
    [SerializeField] private AudioClip clip;

    private bool teleporting;

    private void Update()
    {
        if (GameManager.input.Gameplay.Interact.triggered && isInTeleporter)
        {
            teleporting = true;
            PlayerMovement.instance.StopPlayer();
            currentSceneManager.instance.canTeleport = false;
            animator.SetBool("readyToMove", true);
            AudioManager.Instance.PlayClip(clip);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            indication.SetActive(true);
            isInTeleporter = true;
            toTeleport = collision.gameObject;
        }
    }

    public void Teleport()
    {
        teleporting = false;
        isInTeleporter = false;
        if (level != null) level.SetActive(true);

        toTeleport.GetComponent<PlayerMovement>().enabled = true;
        toTeleport.transform.position = teleportPosition.transform.position;
        currentSceneManager.instance.canTeleport = true;
        animator.SetBool("readyToMove", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !teleporting)
        {
            indication.SetActive(false);
            isInTeleporter = false;
            animator.SetBool("readyToMove", false);
        }
    }
}