using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove = true;
    [SerializeField, Range(5,10)] private float speed = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Move(new Vector2(horizontalInput, verticalInput));
        }
    }

    public void Move(Vector2 direction)
    {
        Vector2 movement = direction.normalized;
        rb.velocity = movement * speed;
    }
}
