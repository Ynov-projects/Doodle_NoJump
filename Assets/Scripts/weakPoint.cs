using UnityEngine;

public class weakPoint : MonoBehaviour
{
    public float bounceOnCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.rigidbody;
        Vector3 targetVelocity = new Vector2(bounceOnCollision, rb.velocity.y);
        Vector3 velocity = Vector3.zero;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .001f);
        Destroy(transform.parent.parent.gameObject);
    }
}
