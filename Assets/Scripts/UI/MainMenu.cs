using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject levelSelectionPanel;
    
    [Header("Level Buttons")]
    [SerializeField] private Button[] levelButtons;
    
    [Header("Navigation Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button backButton;
    
    private void Start()
    {
        // Check if we should show level selection panel based on PlayerPrefs
        bool showLevelSelection = PlayerPrefs.GetInt("ShowLevelSelection", 0) == 1;
        
        // Set up the panels based on the flag
        if (mainMenuPanel != null) mainMenuPanel.SetActive(!showLevelSelection);
        if (levelSelectionPanel != null) levelSelectionPanel.SetActive(showLevelSelection);
        
        // Reset the flag for next time
        PlayerPrefs.SetInt("ShowLevelSelection", 0);
        PlayerPrefs.Save();
        
        // Set up button listeners
        if (playButton != null) playButton.onClick.AddListener(OpenLevelSelection);
        if (backButton != null) backButton.onClick.AddListener(BackToMainMenu);
        
        // Set up level buttons
        SetupLevelButtons();
    }
    
    public void OpenLevelSelection()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (levelSelectionPanel != null) levelSelectionPanel.SetActive(true);
    }
    
    public void BackToMainMenu()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        if (levelSelectionPanel != null) levelSelectionPanel.SetActive(false);
    }
    
    private void SetupLevelButtons()
    {
        if (levelButtons == null || levelButtons.Length == 0) return;
        
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1; // Level1, Level2, etc.
            
            if (levelButtons[i] != null)
            {
                levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));
            }
        }
    }
    
    public void LoadLevel(int levelIndex)
    {
        string sceneName = "Level" + levelIndex;
        
        // Check if the scene exists in build settings
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene " + sceneName + " is not in the build settings!");
        }
    }
}