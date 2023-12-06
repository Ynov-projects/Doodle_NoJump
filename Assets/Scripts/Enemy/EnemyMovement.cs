using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform[] checkpoints;
    int index = 0;

    Transform destination;
    public Transform enemy;

    public float Speed;

    void Start()
    {
        destination = checkpoints[index];
    }

    void Update()
    {
        Vector2 dir = destination.position - enemy.position;
        enemy.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(enemy.position, destination.position) < 0.3f)
        {
            index = (index + 1) % checkpoints.Length;
            destination = checkpoints[index];
            enemy.localScale = new Vector2(-enemy.localScale.x, enemy.localScale.y);
        }
    }
}
