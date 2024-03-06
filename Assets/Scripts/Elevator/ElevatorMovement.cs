using System.Threading;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    private Transform _startPos;
    private Transform _endPos;

    [SerializeField] private Transform[] checkpoints;
    [SerializeField] private GameObject elevator;

    private int startintPoint = 0;

    [SerializeField] private float _speed;

    private bool active;
    [SerializeField] private bool toActivate;

    private bool isInRange;

    private float timer = 0;

    void Update()
    {
        if (toActivate && active || !toActivate)
        {

            timer += Time.deltaTime;
            if (Vector3.Distance(elevator.transform.position, _endPos.position) <= 0.05f && !isInRange)
            {
                isInRange = true;
                startintPoint++;
                changeCheckpoints();
                timer = 0;  
            }
            
            if(Vector3.Distance(elevator.transform.position, _startPos.position) >= 1f) 
                isInRange = false;

            elevator.transform.position = Vector3.Lerp(
                _startPos.position,
                _endPos.position,
                timer / _speed);
        }
    }

    private void Start()
    {
        changeCheckpoints();
    }

    private void changeCheckpoints()
    {
        _startPos = checkpoints[startintPoint % checkpoints.Length];
        _endPos = checkpoints[(startintPoint + 1) % checkpoints.Length];
    }

    public void activate()
    {
        if (toActivate)
        {
            active = true;
            elevator.GetComponent<SpriteRenderer>().color = GameManager.activeColor;
        }
    }

    public void desactivate()
    {
        if (toActivate)
        {
            active = false;
            elevator.GetComponent<SpriteRenderer>().color = GameManager.inactiveColor;
        }
    }

    public void changePermanantState()
    {
        if (!active) activate();
        else desactivate();
        
    }
}
