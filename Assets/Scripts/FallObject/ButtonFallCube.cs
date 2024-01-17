using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject fallCube;
    public void activate()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        fallCube.GetComponent<Rigidbody2D>().gravityScale = 5.0f;
    }

    public void desactivate()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
        fallCube.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
    }
}
