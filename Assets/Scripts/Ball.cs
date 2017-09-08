using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Score
{

    public class Ball : MonoBehaviour
    {
        public int myDir;
        private float y;
        public float speed = 30;
        public Score score;
        public float resetTime;
        void Start()
        {
            // Calling initial velocity
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }

        void Update()
        {
            // Makes the ball respawn and stay in place for x amount of seconds

            if (this.transform.position.x >= 35f)
            {
                this.transform.position = new Vector3(0f, 0f, 0f);
                GetComponent<Rigidbody2D>().velocity = Vector2.right * 0;
                Invoke("ReSet", resetTime);
            }

            if (this.transform.position.x <= -35f)
            {
                this.transform.position = new Vector3(0f, 0f, 0f);
                GetComponent<Rigidbody2D>().velocity = Vector2.right * 0;
                Invoke("ReSet", resetTime);
            }
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
            // Makes the ball rebound

            Vector2 dir = new Vector2(myDir, y).normalized;

            // Makes the ball rebound in different directions 
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            score.scoreChange = false;
        }
    }
}