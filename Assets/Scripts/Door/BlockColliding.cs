using UnityEngine;

public class BlockColliding : MonoBehaviour
{
    [SerializeField] private Item item;

    [SerializeField] private int numberOfItems;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (item.Quantity >= numberOfItems)
        {
            item.Quantity -= numberOfItems;
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
