using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        Move();
        //Animate();
        //moveInput.x = Input.GetAxisRaw("Horizontal");
       // moveInput.y = Input.GetAxisRaw("Vertical");
    }
    
    private void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        if (Horizontal == 0 && Vertical == 0)
        {
            rb.velocity = new Vector2 (0, 0);
            return;
        }
        moveInput = new Vector2(Horizontal, Vertical);
        rb.velocity = moveInput * moveSpeed * Time.fixedDeltaTime;
    }
    private void Animate()
    {
        animator.SetFloat("MovementX", moveInput.x);
        animator.SetFloat("MovementY", moveInput.y);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
