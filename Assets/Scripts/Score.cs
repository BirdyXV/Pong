using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{

    public class Score : MonoBehaviour
    {
        public Text scoreBoard;
        public Text playerText;
        public Text enemyText;


        private GameObject ball;
        private int leftScore = 0;
        private int rightScore = 0;
        public bool scoreChange;
        // Use this for initialization
        void Start()
        {
            // Finding the pong ball
            ball = GameObject.Find("PongBall");
        }

        // Update is called once per frame
        void Update()
        {
            ScoreChange();
            PlayerWin();
            EnemyWin();
        }

        void ScoreChange()
        {
            // If the ball goes past -35 on the x then the  Enemy's score will ascend by 1
            if (ball.transform.position.x <= -35f && !scoreChange)
            {
                rightScore++;
                scoreChange = true;
            }

            // If the ball goes past 35 on the x then the Player's score will ascend by 1
            if (ball.transform.position.x >= 35f && !scoreChange)
            {
                leftScore++;
                scoreChange = true;
            }

            // Makes the UI Text ascend
            scoreBoard.text = leftScore.ToString() + " - " + rightScore.ToString();
        }

        void PlayerWin()
        {
            if (leftScore > 10)
            {
                Application.Quit();
            }
        }

        void EnemyWin()
        {
            if (rightScore > 10)
            {
                Application.Quit();
            }
        }
    }
}