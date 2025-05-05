using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private float startTime;
    private EndScreenManager endScreenManager;


    private void Start()
    {
        startTime = Time.time;
        endScreenManager = FindObjectOfType<EndScreenManager>();
    }

   private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Obstacle"))
    {
        endScreenManager.ShowAttemptFailed();
        gameObject.SetActive(false);
    }
    else if (other.CompareTag("Finish"))
    {
        float completionTime = Time.time - startTime;

        if (IsLastLevel())
        {
            endScreenManager.ShowLevelComplete(completionTime);
            gameObject.SetActive(false);
        }
        else
        {
            GameManager.instance.LoadNextLevel();
        }
    }
}

    private bool IsLastLevel()
    {
        return SceneManager.GetActiveScene().buildIndex ==
               SceneManager.sceneCountInBuildSettings - 1;
    }
}
