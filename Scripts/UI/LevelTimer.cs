using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inGameTimerText;
    [SerializeField] private EndScreenManager endScreenManager;
    
    private float currentTime = 0f;
    private bool isTimerRunning = false;

    private void Start()
    {
        // Start the timer when the level begins
        StartTimer();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            // Update timer
            currentTime += Time.deltaTime;
            
            // Update the in-game timer display if available
            if (inGameTimerText != null)
            {
                inGameTimerText.text = FormatTime(currentTime);
            }
        }
    }

    public void StartTimer()
    {
        currentTime = 0f;
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 100) % 100);
        
        // Format as mm:ss:ms
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    // Call this when player completes the level
    public void OnLevelComplete()
    {
        StopTimer();
        endScreenManager.ShowLevelComplete(currentTime);
    }

    // Call this when player fails the level
    public void OnLevelFailed()
    {
        StopTimer();
        endScreenManager.ShowAttemptFailed();
    }
}