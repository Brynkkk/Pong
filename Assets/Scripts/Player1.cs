using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(0, directionY).normalized;

        if (moveDirection != Vector2.zero)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }

    public void TriggerAttack()
    {
        animator.SetTrigger("attack");
    }

    public void TriggerDeath()
    {
        animator.SetTrigger("death");
    }
}
