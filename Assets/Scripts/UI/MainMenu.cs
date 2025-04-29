using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject levelSelectionPanel;

    [Header("Buttons")]
    [SerializeField] private Button playButton;
    
    void Start()
    {
        // Make sure main menu is active and level selection is inactive at start
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        if (levelSelectionPanel != null) levelSelectionPanel.SetActive(false);
        
        // Add listener to play button
        if (playButton != null)
        {
            playButton.onClick.AddListener(OpenLevelSelection);
        }
        else
        {
            Debug.LogError("Play button reference is missing!");
        }
    }
    
    public void OpenLevelSelection()
    {
        // Switch panels
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (levelSelectionPanel != null) levelSelectionPanel.SetActive(true);
        else Debug.LogError("Level Selection Panel reference is missing!");
    }
    
    public void BackToMainMenu()
    {
        // Return to main menu
        if (levelSelectionPanel != null) levelSelectionPanel.SetActive(false);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
    }
}