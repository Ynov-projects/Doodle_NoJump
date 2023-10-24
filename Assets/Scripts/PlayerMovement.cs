using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    public Animator animator;

    public static PlayerMovement instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        // On met la local scale dans le sens du déplacement du personnage
        // Permet de mettre le sprite dans le sens de la marche du personnage
        transform.localScale = rb.velocity.x <= -0.3f ? new Vector3(-1, 1, 1) : (rb.velocity.x >= 0.3f) ? new Vector3(1, 1, 1) : transform.localScale;

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    private void Update()
    { 
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .001f);
    }
}
