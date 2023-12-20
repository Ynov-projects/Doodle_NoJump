using UnityEngine;

public class DoorColliding : MonoBehaviour
{
    [SerializeField] private Item key;

    [SerializeField] private int numberOfItems;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(key.Quantity >= numberOfItems)
        {
            key.Quantity--;
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
