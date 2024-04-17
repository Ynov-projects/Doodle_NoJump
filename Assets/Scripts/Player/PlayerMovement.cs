using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    [SerializeField] private float jumpForce;
    public bool isClimbing;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;

    public bool isJumping;
    public bool canJump;

    public Animator animator;

    private int collidings;

    public static PlayerMovement instance;

    public ParticleSystem ParticleSystem1, ParticleSystem2;
    [SerializeField] private AudioClip clip;

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
        //horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        //verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;

        // On met la local scale dans le sens du d�placement du personnage
        // Permet de mettre le sprite dans le sens de la marche du personnage
        transform.localScale = rb.velocity.x <= -0.3f ? new Vector3(-1, 1, 1) : (rb.velocity.x >= 0.3f) ? new Vector3(1, 1, 1) : transform.localScale;

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    private void Update()
    {
        MovePlayer(horizontalMovement, verticalMovement);

        Vector2 RawMovementInput = GameManager.input.Gameplay.Movement.ReadValue<Vector2>();
        horizontalMovement = (int)(RawMovementInput * Vector2.right).normalized.x * moveSpeed;
        verticalMovement = (int)(RawMovementInput * Vector2.up).normalized.y * climbSpeed;

        if (GameManager.input.Gameplay.Jumping.triggered) isJumping = canJump && collidings > 0;
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = Vector3.zero;
        if (isClimbing)
        {
            targetVelocity = new Vector2(0, _verticalMovement);
        }
        else
        {
            if (isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
            rb.AddForce(Physics.gravity * Time.deltaTime * 100);
            targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        }
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            if (collidings == 0)
            {
                ParticleSystem1.Play();
                ParticleSystem2.Play();
                AudioManager.Instance.PlayClip(clip);
            }
            collidings++;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger) collidings--;
    }
}
