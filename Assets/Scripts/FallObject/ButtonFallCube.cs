using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject fallCube;
    private bool falling;
    
    public void activate()
    {
        falling = !falling;
        Rigidbody2D rb = fallCube.GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().color = falling ? Color.yellow : Color.blue;
        rb.gravityScale = falling ? 5.0f : 0.0f;
        rb.velocity = falling ? rb.velocity : Vector3.zero;
    }

    public void desactivate()
    {    }
}
