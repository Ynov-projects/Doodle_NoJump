using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideElevator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "elevator")
        {
            Animator animator = collision.GetComponent<Animator>();
            animator.SetInteger("sideCollider", (animator.GetInteger("sideCollider") + 1) % 2);
            Debug.Log(animator.GetInteger("sideCollider"));
        }
    }
}
