using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f; // Initial countdown time
    public bool timeIsRunning = false; // Start timer when needed
    public TMP_Text timeText;

    void Start()
    {
        timeIsRunning = true; // Start timer when the game starts (you might want to change this depending on your game logic)
    }

    void Update()
    {
        if (timeIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Subtract deltaTime to count down
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timeIsRunning = false; // Stop the timer when it reaches 0
                // You might want to trigger an event or perform some action when the timer reaches 0
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Adjust display format
    }
}