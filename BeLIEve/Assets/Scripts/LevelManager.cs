using UnityEngine;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.RegisterLevel(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
