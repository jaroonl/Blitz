using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenManager : MonoBehaviour
{
    [Header("Screen References")]
    [SerializeField] private GameObject levelCompleteScreen;
    [SerializeField] private GameObject attemptFailedScreen;
    
    [Header("Level Complete Elements")]
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button levelsButton;
    
    [Header("Attempt Failed Elements")]
    [SerializeField] private Button restartButton;
    [SerializeField] private Button homeButton;

    private void Start()
    {
        // Make sure both screens are hidden at the start
        levelCompleteScreen.SetActive(false);
        attemptFailedScreen.SetActive(false);
        
        // Add click listeners to buttons
        nextButton.onClick.AddListener(GoToNextLevel);
        levelsButton.onClick.AddListener(GoToLevelSelection);
        restartButton.onClick.AddListener(RestartLevel);
        homeButton.onClick.AddListener(GoToMainMenu);
    }

    // Call this function when the player successfully completes the level
    public void ShowLevelComplete(float completionTime)
    {
        // Format time as xx:xx (minutes:seconds)
        string formattedTime = FormatTime(completionTime);
        
        // Update the time text
        timeText.text = "Time: " + formattedTime;
        
        // Show the level complete screen
        levelCompleteScreen.SetActive(true);
    }

    // Call this function when the player fails the level
    public void ShowAttemptFailed()
    {
        // Show the attempt failed screen
        attemptFailedScreen.SetActive(true);
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 100) % 100);
        
        // Format as mm:ss:ms
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    private void GoToNextLevel()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // Load the next scene (assumes next level is the next scene in build settings)
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private void GoToLevelSelection()
    {
        // Load the level selection scene
        // Replace "LevelSelection" with your actual scene name
        SceneManager.LoadScene("LevelSelection");
    }

    private void RestartLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoToMainMenu()
    {
        // Load the main menu scene
        // Replace "MainMenu" with your actual scene name
        SceneManager.LoadScene("MainMenu");
    }
}