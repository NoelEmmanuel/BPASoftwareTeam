using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rb.velocity = movement * moveSpeed;
    }

    void fixedUpdate() 
    {
        //Movement
        //rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
    }
}
