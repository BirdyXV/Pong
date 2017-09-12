using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Score
{
    public class Ball : MonoBehaviour
    {
        public float speed = 30;
        public Score score;
        public float resetTime;
        [HideInInspector]
        public int myDir;

        private float y;

        void Start()
        {
            // Calling initial velocity
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }

        void Update()
        {

            // IF ball is at 35 on the x
            if (this.transform.position.x >= 35f)
            {
                // The ball respawn and stay in place for x amount of seconds
                this.transform.position = new Vector3(0f, 0f, 0f);
                GetComponent<Rigidbody2D>().velocity = Vector2.right * 0;
                Invoke("ReSet", resetTime);
            }

            // IF ball is at -35 on the x
            if (this.transform.position.x <= -35f)
            {
                // The ball respawn and stay in place for x amount of seconds
                this.transform.position = new Vector3(0f, 0f, 0f);
                GetComponent<Rigidbody2D>().velocity = Vector2.right * 0;
                Invoke("ReSet", resetTime);
            }
        }

        // Creating references for collision
        float hitFactor(Vector2 ballPos, Vector2 paddlePos,
                     float paddleHeight)
        {
            return (ballPos.y - paddlePos.y) / paddleHeight;
        }

        // Creating a variable to reference Collision2D
        void OnCollisionEnter2D(Collision2D col)
        {
            // Calling the player paddle 
            if (col.gameObject.name == "Player")
            {
                // Calculating the hit factor
                y = hitFactor(transform.position,
                                    col.transform.position,
                                    col.collider.bounds.size.y);
                myDir = 1;

                // Makes the ball rebound
                Vector2 dir = new Vector2(myDir, y).normalized;

                // Makes the ball rebound in different directions 
                GetComponent<Rigidbody2D>().velocity = dir * speed;
            }

            // Calling the enemy paddle
            if (col.gameObject.name == "Enemy")
            {
                // Calculating the hit factor
                y = hitFactor(transform.position,
                                    col.transform.position,
                                    col.collider.bounds.size.y);
                myDir = -1;

                // Makes the ball rebound
                Vector2 dir = new Vector2(myDir, y).normalized;

                // Makes the ball rebound in different directions 
                GetComponent<Rigidbody2D>().velocity = dir * speed;
            }
        }

        void ReSet()
        {
            // Makes the ball shoot to the enemy once it respawns
            Vector2 dir = new Vector2(10, myDir).normalized;

            // Makes the ball rebound
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            // Making the scoreChange boolean = false so the score doesn't continuously ascend
            score.scoreChange = false;
        }
    }
}