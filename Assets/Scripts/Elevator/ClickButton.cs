using UnityEngine;
using UnityEngine.Events;

public class ClickButton : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private UnityEvent activate;
    [SerializeField] private UnityEvent desactivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("pressed", true);
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        activate.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("pressed", false);
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        desactivate.Invoke();
    }
}
