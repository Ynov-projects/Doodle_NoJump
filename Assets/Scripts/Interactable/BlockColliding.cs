using UnityEngine;

public class BlockColliding : MonoBehaviour
{
    [SerializeField] private Item item;

    [SerializeField] private int numberOfItems;
    [SerializeField] private AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player" || collision.tag == "LegPlayer") && item.Quantity >= numberOfItems)
        {
            item.Quantity -= numberOfItems;
            UIManager.Instance.UpdateUI();
            gameObject.GetComponent<SpriteRenderer>().color = GameManager.activeColor;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            AudioManager.Instance.PlayClip(clip);
        }
    }
}
