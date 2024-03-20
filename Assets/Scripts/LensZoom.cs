using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LensZoom : MonoBehaviour
{

    [SerializeField] private Camera cam;

    public float zoom;
    public float speed;
    private float orthograpicSize;

    private void Start()
    {
        orthograpicSize = cam.orthographicSize;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * speed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, orthograpicSize, Time.deltaTime * speed);
    }
}
