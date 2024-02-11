using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAutoChild : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent != transform)
        {
            if (collision.tag == "LegPlayer") collision.transform.parent.parent = transform;
            else if (collision.tag != "Player") collision.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent != transform)
        {
            if (collision.tag == "LegPlayer") collision.transform.parent.parent = null;
            else if (collision.tag != "Player") collision.transform.parent = null;
        }
    }
}
