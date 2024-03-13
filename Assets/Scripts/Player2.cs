using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical2");

        moveDirection = new Vector2(0, directionY).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }
}
