using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;
    [SerializeField] private GameObject elevator;

    [SerializeField] private float _speed;
    private bool active;
    [SerializeField] private bool toActivate;

    void Update()
    {
        if (toActivate && active || !toActivate)
        {
            elevator.transform.position = Vector3.Lerp(
                _startPos.position,
                _endPos.position,
                Mathf.PingPong(Time.time / _speed, 1));
        }
    }

    public void activate()
    {
        if (toActivate)
        {
            active = true;
            elevator.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    public void desactivate()
    {
        if (toActivate)
        {
            active = false;
            elevator.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}
