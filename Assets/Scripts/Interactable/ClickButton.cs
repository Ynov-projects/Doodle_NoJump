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
        if (gameObject.GetComponent<SpriteRenderer>().color != GameManager.activeColor)
        {
            AudioManager.Instance.PlayClip(clip);
            gameObject.GetComponent<SpriteRenderer>().color = GameManager.activeColor;
            activate.Invoke();
        }
    }

    private void desactivateEvents()
    {
        if (gameObject.GetComponent<SpriteRenderer>().color != GameManager.inactiveColor)
        {
            AudioManager.Instance.PlayClip(clip);
            gameObject.GetComponent<SpriteRenderer>().color = GameManager.inactiveColor;
            desactivate.Invoke();
        }
    }
}