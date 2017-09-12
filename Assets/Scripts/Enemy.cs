using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Ball;

    void FixedUpdate()
    {
        // Calling Move
        Move();
    }
    void Move()
    {
        // IF the balls transform.y is greater than the enemy's transform.y
        if (Ball.transform.position.y > transform.position.y)
        {
            // Move the ball towards the enemy's transform.y
            transform.position = new Vector3(transform.position.x, transform.position.y + .4f, transform.position.z);
        }

        // IF the balls transform.y is less than the enemy's transform.y (reversing the code)
        if (Ball.transform.position.y < transform.position.y)
        {
            // Move the ball towards the enemy's -transform.y
            transform.position = new Vector3(transform.position.x, transform.position.y - .4f, transform.position.z);
        }
    }
}
