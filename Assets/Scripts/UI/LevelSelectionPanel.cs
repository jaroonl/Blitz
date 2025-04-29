using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionPanel : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Button backButton;
    [SerializeField] private Button[] levelButtons;
    
    [Header("Level Names")]
    [SerializeField] private string[] levelSceneNames;
    
    // Reference to the main menu panel
    [SerializeField] private GameObject mainMenuPanel;
    
    void Start()
    {
        // Setup back button
        if (backButton != null)
        {
            backButton.onClick.AddListener(GoBackToMainMenu);
        }
        else
        {
            Debug.LogError("Back button reference is missing!");
        }
        
        // Setup level buttons
        for (int i = 0; i < levelButtons.Length && i < levelSceneNames.Length; i++)
        {
            int levelIndex = i; // Need to capture the index for the lambda
            if (levelButtons[i] != null)
            {
                levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));
            }
        }
    }
    
    // Method to handle back button click
    public void GoBackToMainMenu()
    {
        // Hide this panel
        gameObject.SetActive(false);
        
        // Show main menu panel
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
        }
        else
        {
            // If mainMenuPanel reference is not set, try to find MainMenu component
            MainMenu mainMenu = FindObjectOfType<MainMenu>();
            if (mainMenu != null)
            {
                // Call the method on MainMenu script to handle going back
                mainMenu.BackToMainMenu();
            }
            else
            {
                Debug.LogError("Could not find MainMenu reference!");
            }
        }
    }
    
    void LoadLevel(int index)
    {
        if (index >= 0 && index < levelSceneNames.Length)
        {
            Debug.Log("Loading level: " + levelSceneNames[index]);
            
            // Make sure the scene is in build settings before loading
            if (Application.CanStreamedLevelBeLoaded(levelSceneNames[index]))
            {
                SceneManager.LoadScene(levelSceneNames[index]);
            }
            else
            {
                Debug.LogError("Scene '" + levelSceneNames[index] + "' is not in Build Settings!");
            }
        }
        else
        {
            Debug.LogError("Invalid level index: " + index);
        }
    }
}