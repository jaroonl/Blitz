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
        levelCompleteScreen.SetActive(false);
        attemptFailedScreen.SetActive(false);
        
        nextButton.onClick.AddListener(GoToNextLevel);
        levelsButton.onClick.AddListener(GoToLevelSelection);
        restartButton.onClick.AddListener(RestartLevel);
        homeButton.onClick.AddListener(GoToMainMenu);
    }

    public void ShowLevelComplete(float completionTime)
    {
        string formattedTime = FormatTime(completionTime);
        
        timeText.text = "Time: " + formattedTime;

        levelCompleteScreen.SetActive(true);
    }

    public void ShowAttemptFailed()
    {
        attemptFailedScreen.SetActive(true);
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 100) % 100);
        
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    private void GoToNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private void GoToLevelSelection()
    {
        SceneManager.LoadScene("MainMenu");
        
        PlayerPrefs.SetInt("ShowLevelSelection", 1);
        PlayerPrefs.Save();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
        PlayerPrefs.SetInt("ShowLevelSelection", 0);
        PlayerPrefs.Save();
    }
}