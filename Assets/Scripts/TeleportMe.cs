using System.Collections;
using UnityEngine;

public class TeleportMe : MonoBehaviour
{
    [SerializeField] private GameObject teleportPosition;
    [SerializeField] private GameObject level;

    private bool isInTeleporter;
    [SerializeField] private bool isLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInTeleporter = true;
        StartCoroutine(Teleport(collision.gameObject));
    }

    IEnumerator Teleport(GameObject collision)
    {
        yield return new WaitForSeconds(2f);
        if (isInTeleporter)
        {
            collision.transform.position = teleportPosition.transform.position;
            if (isLevel) level.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTeleporter = false;
    }
}
