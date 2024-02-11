using UnityEngine;

public class LevelDoor: MonoBehaviour
{
    private void DesactivateLevels()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Level")) go.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.position = Vector3.zero;
            DesactivateLevels();
        }
    }
}