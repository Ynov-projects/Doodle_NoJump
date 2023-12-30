using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMe : MonoBehaviour
{
    [SerializeField] private GameObject teleportPosition;

    private bool isInTeleporter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInTeleporter = true;
        StartCoroutine(Teleport(collision.gameObject));
    }

    IEnumerator Teleport(GameObject collision)
    {
        yield return new WaitForSeconds(2f);
        if(isInTeleporter) collision.transform.position = teleportPosition.transform.position;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTeleporter = false;
    }
}
