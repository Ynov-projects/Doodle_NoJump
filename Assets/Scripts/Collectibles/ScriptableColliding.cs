using UnityEngine;
using UnityEngine.Events;

public class ScriptableColliding : MonoBehaviour
{
    [SerializeField] private Item scriptableItem;
    [SerializeField] private UnityEvent destroyedEvent;

    private bool alreadyCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !alreadyCollected)
        {
            alreadyCollected = true;
            GetComponent<Collider2D>().enabled = false;
            if(destroyedEvent != null) destroyedEvent.Invoke();
            Destroy(gameObject);
            scriptableItem.Quantity++;
            UIManager.Instance.UpdateUI();
        }
    }
}
