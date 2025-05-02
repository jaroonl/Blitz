using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
// Static instance of the Game Manager,
// can be access from anywhere
public static GameManager instance = null;


// Called when the object is initialized
void Awake()
{
// if it doesn't exist
if(instance == null)
{
// Set the instance to the current object (this)
instance = this;
}
// There can only be a single instance of the game manager
else if(instance != this)
{
// Destroy the current object, so there is just one manager
Destroy(gameObject);
}
// Don't destroy this object when loading scenes
DontDestroyOnLoad(gameObject);
print("GameManager Initialized");
}



public void LoadNextLevel()
{
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex + 1);
}


}


