using UnityEngine;

public class ScriptableColliding : MonoBehaviour
{
    [SerializeField] private Item scriptableItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        scriptableItem.Quantity++;
    }
}
