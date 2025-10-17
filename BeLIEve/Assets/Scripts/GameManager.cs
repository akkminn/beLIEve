using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int lives = 5;
    private string lastLevel;
    private bool isProcessingDeath = false; // Add this

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void RegisterLevel(string levelName)
    {
        lastLevel = levelName;
    }

    public void PlayerDied()
    {
        if (isProcessingDeath) return;
        
        isProcessingDeath = true;
        lives--;
        SceneManager.LoadScene("RetryScene");
    }

    public void RetryLevel()
    {
        isProcessingDeath = false;
        SceneManager.LoadScene(lastLevel);
    }

    public void QuitGame()
    {
        isProcessingDeath = false;
        SceneManager.LoadScene("MainMenu");
    }
}
