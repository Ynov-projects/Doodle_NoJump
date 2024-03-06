using UnityEngine;
using UnityEngine.Events;

public class ClickButton : MonoBehaviour
{
    [SerializeField] private UnityEvent activate;
    [SerializeField] private UnityEvent desactivate;
    private int numberOfItemsColliding;
    [SerializeField] private bool permanent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "elevator")
        {
            numberOfItemsColliding++;
            gameObject.GetComponent<SpriteRenderer>().color = GameManager.activeColor;
            activate.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "elevator")
        {
            numberOfItemsColliding--;
            if (numberOfItemsColliding == 0 && !permanent)
            {
                gameObject.GetComponent<SpriteRenderer>().color = GameManager.inactiveColor;
                desactivate.Invoke();
            }
        }
    }
}
