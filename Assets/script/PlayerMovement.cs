using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer Sprite;
    private Animator animator;
    private BoxCollider2D col;

    [SerializeField] private LayerMask jumpablegorund;

    private float driX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource JumpSFX;

    // Start is called before the first frame update
    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        driX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(driX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            JumpSFX.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        MovementUpdate();
    }

    private void MovementUpdate()
    {
        MovementState state;

        if (driX > 0f)
        {
            state = MovementState.running;
            Sprite.flipX = false;


        }
        else if (driX < 0f)
        {
            state = MovementState.running;
            Sprite.flipX = true;

        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("State", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpablegorund);
    }
}
