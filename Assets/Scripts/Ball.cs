using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 30;
    

    void Start()
    {
        // Calling initial velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    
    // Creating the hit factor
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                    float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Calling the player paddle 
        if (col.gameObject.name == "Player")
        {
            // Calculating the hit factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Makes the ball rebound
            Vector2 dir = new Vector2(1, y).normalized;

            // Makes the ball rebound in different directions 
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Calling the enemy paddle
        if (col.gameObject.name == "Enemy")
        {
            // Calculating the hit factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Makes the ball rebound
            Vector2 dir = new Vector2(-1, y).normalized;

            // Makes the ball rebound in different directions 
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}
