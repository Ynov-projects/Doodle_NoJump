using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    public float bounceOnCollision;
    [SerializeField] private BoxCollider2D enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy.enabled = false;
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        Vector3 targetVelocity = new Vector2(bounceOnCollision, rb.velocity.y);
        Vector3 velocity = Vector3.zero;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .001f);
        Destroy(transform.parent.parent.gameObject);
    }
}
