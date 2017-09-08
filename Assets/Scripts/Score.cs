using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{

    public class Score : MonoBehaviour
    {
        public Text scoreBoard;
        public GameObject ball;

        private int leftScore = 0;
        private int rightScore = 0;
        public bool scoreChange;
        // Use this for initialization
        void Start()
        {
            ball = GameObject.Find("PongBall");

        }

        // Update is called once per frame
        void Update()
        {

            if (ball.transform.position.x <= -35f && !scoreChange)
            {
                rightScore++;
                scoreChange = true;
            }

            if (ball.transform.position.x >= 35f && scoreChange)
            {
                leftScore++;
                scoreChange = true;
            }

            scoreBoard.text = leftScore.ToString() + " - " + rightScore.ToString();

        }
    }
}