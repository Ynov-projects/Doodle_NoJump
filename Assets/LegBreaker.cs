using UnityEngine;

public class LegBreaker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement.instance.canJump = false;
    }
}
