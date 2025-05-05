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
        StartTimer();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTime += Time.deltaTime;

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
        
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void OnLevelComplete()
    {
        StopTimer();
        endScreenManager.ShowLevelComplete(currentTime);
    }

    public void OnLevelFailed()
    {
        StopTimer();
        endScreenManager.ShowAttemptFailed();
    }
}