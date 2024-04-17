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

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.performed && isInTrigger)
        {
            animator.SetBool("readyToMove", true);
            PlayerMovement.instance.enabled = false;
            PlayerMovement.instance.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
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
        PlayerMovement.instance.enabled = true;
        DesactivateLevels();
    }
}