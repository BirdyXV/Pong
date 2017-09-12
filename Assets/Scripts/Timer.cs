using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public Text countdownTimer;

    private string clockTime;

    // Use this for initialization
    void Update()
    {
        // Calling Clock
        Clock();
    }

    void Clock()
    {
        // Creating mins (minutes) variable and telling it how long a minute is
        int mins = Mathf.FloorToInt(timer / 60);
        // Creating secs (seconds) variable and telling it how long a second is
        int secs = Mathf.FloorToInt(timer - mins * 60);
        // Makes the timer countdown each second
        countdownTimer.text = mins.ToString() + "  :  " + secs.ToString();
        // Slows down the countdown timer to be in realtime
        timer -= Time.deltaTime;
        // When the timer reaches 0 
        if (timer <= 0)
        {
            // The Application will close
            Application.Quit();
        }
    }
}
