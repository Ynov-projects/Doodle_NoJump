using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOutZone : MonoBehaviour
{
    [SerializeField] private GameObject fallCube;
    private Vector3 spawnPoint;


    private void Start()
    {
        spawnPoint = fallCube.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fallCube")
        {
            fallCube.transform.position = spawnPoint;
            fallCube.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
