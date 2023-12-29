using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D bounceTrampoline;

    public void activate()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        bounceTrampoline.enabled = true;
    }

    public void desactivate()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
        bounceTrampoline.enabled = false;
    }
}
