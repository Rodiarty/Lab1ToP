using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]

public class PlayerController : MonoBehaviour
{
    [SerializeField]   private float speed = 1f;
    [SerializeField]   private float jumpHeight = 0.5f;
    [SerializeField]   private GroundChecker groundChecker;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private bool facingRight;
   
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");

        var velocity = rb.velocity;
        velocity.x = horizontal * speed;

        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.IsOnGround)
        {
            var v = Mathf.Sqrt(-2 * jumpHeight * Physics2D.gravity.y);
            velocity.y = v - Physics2D.gravity.y * Time.fixedDeltaTime;
        }

        rb.velocity = velocity;

        animator.SetFloat("VelocityY", Mathf.Abs(velocity.y));
        animator.SetFloat("VelocityX", Mathf.Abs(velocity.x));

        if (velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
          
    }
}
