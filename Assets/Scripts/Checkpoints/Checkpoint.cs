using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().color = GameManager.activeColor;
        currentSceneManager.instance.spawnPoint = transform.position;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
