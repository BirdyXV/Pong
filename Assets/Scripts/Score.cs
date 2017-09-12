using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{

    public class Score : MonoBehaviour
    {
        public Text scoreBoard;

        [HideInInspector]
        public bool scoreChange;


        private GameObject ball;
        private int leftScore = 0;
        private int rightScore = 0;

        void Start()
        {
            // Finding the pong ball
            ball = GameObject.Find("PongBall");
        }

        // Update is called once per frame
        void Update()
        {
            // Calling functions so they will work
            ScoreChange();
        }

        void ScoreChange()
        {
            // If the ball is at -35 on x
            if (ball.transform.position.x <= -35f && !scoreChange)
            {
                // The score will add 1 point to the Enemy
                rightScore++;
                scoreChange = true;
            }

            // If the ball is at 35 on x
            if (ball.transform.position.x >= 35f && !scoreChange)
            {
                // The score will add 1 point to the Player
                leftScore++;
                scoreChange = true;
            }
            // Makes the UI Text ascend
            scoreBoard.text = leftScore.ToString() + " - " + rightScore.ToString();
        }
    }
}