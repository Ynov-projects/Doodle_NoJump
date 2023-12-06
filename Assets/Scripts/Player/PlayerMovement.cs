using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    public bool isClimbing;

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
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;

        // On met la local scale dans le sens du d�placement du personnage
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
        Vector3 targetVelocity = Vector3.zero;
        if (isClimbing)
        {
            targetVelocity = new Vector2(0, _verticalMovement);
        }
        else
        {
            rb.AddForce(Physics.gravity * Time.deltaTime * 100);
            targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        }
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, 0.1f);
    }
}
