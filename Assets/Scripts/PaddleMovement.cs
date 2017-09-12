using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 30;
    public string axis = "Vertical";

    void FixedUpdate()
    {
        // Creating 'v' variable and getting the vertical axis 
        float v = Input.GetAxis("Vertical");
        // Makes the ball move up and down with 'W' & 'S'
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}
