﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 10;
    public float speed = 400;
    public GameObject GroundCheck;
    public LayerMask playerMask;

    private float horizontalMove;
    private Vector3 velocity;
    private Rigidbody2D rb;
    private bool facingRight = true;
    public bool isGrounded;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * speed;
        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    public void setIsGrounded(bool b)
    {
        isGrounded = b;
    }

    void FixedUpdate()
    {
        Move(horizontalMove * Time.deltaTime);
    }

    void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move, rb.velocity.y);
        rb.velocity = targetVelocity;

        if (move > 0 && !facingRight || move < 0 && facingRight)
            Flip();
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity += jumpForce * Vector2.up;
            isGrounded = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
