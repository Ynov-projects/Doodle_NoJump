using UnityEngine;
using UnityEngine.Events;

public class ClickButton : MonoBehaviour
{
    [SerializeField] private UnityEvent activate;
    [SerializeField] private UnityEvent desactivate;
    private int numberOfItemsColliding;
    [SerializeField] private bool permanent;

    [SerializeField] private bool switchable;
    private bool activated;
    [SerializeField] private AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "elevator" && collision.gameObject.tag != "LegPlayer")
        {
            numberOfItemsColliding++;
            if (!activated)
                activateEvents();
            else
                desactivateEvents();
            activated = switchable ? !activated : false;
            AudioManager.Instance.PlayClip(clip);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "elevator" && collision.gameObject.tag != "LegPlayer")
        {
            numberOfItemsColliding--;
            if (numberOfItemsColliding == 0 && !permanent && !switchable)
                desactivateEvents();
        }
    }

    private void activateEvents()
    {
        gameObject.GetComponent<SpriteRenderer>().color = GameManager.activeColor;
        activate.Invoke();
    }

    private void desactivateEvents()
    {
        gameObject.GetComponent<SpriteRenderer>().color = GameManager.inactiveColor;
        desactivate.Invoke();
    }
}