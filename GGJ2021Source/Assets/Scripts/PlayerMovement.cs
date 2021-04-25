using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 10;
    public float speed = 400;

    private float horizontalMove;
    private Rigidbody2D rb;
    private bool facingRight = true;
    public bool isGrounded;

    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.IsGamePaused) return;

        horizontalMove = Input.GetAxis("Horizontal") * speed;
        if (Input.GetButtonDown("Jump"))
            Jump();

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
    }

    public void SetIsGrounded(bool b)
    {
        isGrounded = b;
    }

    private void FixedUpdate()
    {
        Move(horizontalMove * Time.deltaTime);
    }

    private void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move, rb.velocity.y);
        rb.velocity = targetVelocity;

        if (move > 0 && !facingRight || move < 0 && facingRight)
            Flip();
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity += jumpForce * Vector2.up;
            isGrounded = false;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Jump", transform.position);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Find("GFX").GetComponent<SpriteRenderer>().flipX = !facingRight;
    }
}