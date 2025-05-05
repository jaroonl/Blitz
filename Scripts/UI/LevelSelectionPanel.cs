using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionPanel : MonoBehaviour
{
    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    [SerializeField] private Button backButton;
    
    [SerializeField] private GameObject mainMenuPanel;
    
    private void Start()
    {
        // Set up button listeners
        if (level1Button != null) level1Button.onClick.AddListener(() => LoadLevel(1));
        if (level2Button != null) level2Button.onClick.AddListener(() => LoadLevel(2));
        if (level3Button != null) level3Button.onClick.AddListener(() => LoadLevel(3));
        if (backButton != null) backButton.onClick.AddListener(BackToMainMenu);
    }
    
    private void LoadLevel(int levelIndex)
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
    
    private void BackToMainMenu()
    {
        // Hide this panel
        gameObject.SetActive(false);
        
        // Show the main menu panel
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
        }
    }
    
    // This method can be called from other scripts to activate this panel
    public void ShowPanel()
    {
        gameObject.SetActive(true);
        
        // Hide the main menu panel
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(false);
        }
    }
}