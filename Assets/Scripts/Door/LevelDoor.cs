using TMPro;
using UnityEngine;

public class LevelDoor: MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Animator animator;

    private void DesactivateLevels()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Level")) go.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetBool("readyToMove", true);
            PlayerMovement.instance.enabled = false;
            player = collision.gameObject;
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    public void EndOfLevel()
    {
        animator.SetBool("readyToMove", false);
        player.transform.position = Vector3.zero;
        PlayerMovement.instance.enabled = true;
        DesactivateLevels();
    }
}