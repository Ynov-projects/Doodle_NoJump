using UnityEngine;

public class ButtonFallCube : MonoBehaviour
{
    public GameObject fallCube;

    public void activate()
    {
        GetComponent<SpriteRenderer>().color = GameManager.activeColor;
        fallCube.GetComponent<Rigidbody2D>().gravityScale = 5.0f;
    }

    public void desactivate()
    {
        // GetComponent<SpriteRenderer>().color = Color.blue;
        // fallCube.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
    }
}