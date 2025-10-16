using UnityEngine;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.RegisterLevel(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
