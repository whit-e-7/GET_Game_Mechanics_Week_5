using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;     // Reference to the TMP Text object for displaying score
    public TMP_Text timerText;     // Reference to the TMP Text object for displaying the timer
    public TMP_Text gameOverText;  // Reference to the TMP Text object for "Game Over" message
    public float gameTime = 30f;   // Timer duration (30 seconds)
    private int score = 0;         // Player's score
    private float timeRemaining;   // Time left on the timer
    private bool isGameOver = false;

    void Start()
    {
        timeRemaining = gameTime;
        gameOverText.gameObject.SetActive(false); // Hide the Game Over text initially
        UpdateScoreText();
        UpdateTimerText();
    }

    void Update()
    {
        if (isGameOver)
            return; // Stop the game if it's over

        // Countdown the timer
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            EndGame();
        }

        UpdateTimerText();
    }

    // Update the score
    public void AddScore(int points)
    {
        if (isGameOver)
            return; // Do not update the score if the game is over

        score += points;
        UpdateScoreText();
    }

    // Update the score TMP text
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Update the timer TMP text
    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();
    }

    // Game over logic
    void EndGame()
    {
        isGameOver = true;
        timerText.text = "Time: 0"; // Display time as 0 at game over
        ShowGameOverText();
    }

    // Display the "Game Over" text with a large font size
    void ShowGameOverText()
    {
        gameOverText.gameObject.SetActive(true); // Show the Game Over text
        gameOverText.text = "GAME OVER"; // Set the message

        // Optional: Make the Game Over text bigger
        gameOverText.fontSize = 100; // Adjust the font size
    }
}
