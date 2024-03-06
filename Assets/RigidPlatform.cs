using UnityEngine;

public class RigidPlatform : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;

    public void activate()
    {
        Color color = spriteRenderer.color;
        color.a = 255;
        spriteRenderer.color = color;
        boxCollider.enabled = true;
    }

    public void desactivate()
    {
        Color color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
        boxCollider.enabled = false;
    }
}
