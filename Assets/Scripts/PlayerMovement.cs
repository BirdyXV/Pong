using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float deceleration = 10f;

    private Rigidbody2D rigid2D;

    void Start()
    {
        // Settings rigid2D as a reference to Rigidbody2D
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Using FixedUpdate as it's best for physics
    void FixedUpdate()
    {
        // Calling Movement & Deceleration
        Movement();
        Deceleration();
    }

    void Movement()
    {
        // Getting Vertical axis so Player can move up and down on the y 
        float v = Input.GetAxisRaw("Vertical");
        // Moves the Player with 'W' & 'S'
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
    }

    void Deceleration()
    {
        // Makes the Player stop moving once you release the 'W' & 'S' keys
        rigid2D.velocity += -rigid2D.velocity * deceleration * Time.deltaTime;
    }
}

