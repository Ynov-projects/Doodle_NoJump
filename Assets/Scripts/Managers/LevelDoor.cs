using TMPro;
using UnityEngine;

public class LevelDoor: MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip clip;

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
            AudioManager.Instance.PlayClip(clip);
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