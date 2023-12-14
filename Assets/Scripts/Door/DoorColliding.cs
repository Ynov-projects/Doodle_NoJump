using UnityEngine;

public class DoorColliding : MonoBehaviour
{
    [SerializeField] private Item key;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(key.Quantity > 0)
        {
            key.Quantity--;
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
