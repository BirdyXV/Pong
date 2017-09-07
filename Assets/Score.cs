using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreBoard;
    public GameObject ball;

    private int leftScore = 0;
    private int rightScore = 0;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.Find("PongBall");
    }

    // Update is called once per frame
    void Update()
    {

        if (ball.transform.position.x <= -17f)
        {
            leftScore++;
        }

        if (ball.transform.position.x >= 17f)
        {
            rightScore++;
        }

    }
}
