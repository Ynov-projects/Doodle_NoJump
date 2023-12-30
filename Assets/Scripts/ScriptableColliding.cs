using UnityEngine;

public class ScriptableColliding : MonoBehaviour
{
    [SerializeField] private Item scriptableItem;

    private bool alreadyCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !alreadyCollected)
        {
            alreadyCollected = true;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
            scriptableItem.Quantity++;
        }
    }
}
