using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAutoChild : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.parent.parent = transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.parent.parent = null;
    }
}
