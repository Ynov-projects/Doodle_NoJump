using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    [SerializeField] private GameObject bounceTrampoline;

    [SerializeField] private bool toActivate;

    private void Start()
    {
        bounceTrampoline.SetActive(!toActivate);
    }

    public void activate()
    {
        if (toActivate)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
            bounceTrampoline.SetActive(true);
        }
    }

    public void desactivate()
    {
        if (toActivate)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
            bounceTrampoline.SetActive(false);
        }
    }
}