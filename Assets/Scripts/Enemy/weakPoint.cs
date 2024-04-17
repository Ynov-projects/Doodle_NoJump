using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    public float bounceOnCollision;
    [SerializeField] private BoxCollider2D enemy;
    [SerializeField] private AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy.enabled = false;
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if(collision.tag == "LegPlayer")
        {
            rb = collision.transform.parent.GetComponent<Rigidbody2D>();
        }
        Vector3 targetVelocity = new Vector2(bounceOnCollision, rb.velocity.y);
        Vector3 velocity = Vector3.zero;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .001f);
        AudioManager.Instance.PlayClip(clip);
        Destroy(transform.parent.parent.gameObject);
    }
}
