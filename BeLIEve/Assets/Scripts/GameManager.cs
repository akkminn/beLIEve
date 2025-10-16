using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int lives = 5;
    private Vector2 playerStartPosition;
    private GameObject player;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerStartPosition = player.transform.position;
    }

    public void PlayerDied()
    {
        lives--;
        if (lives >= 0)
        {
            player.transform.position = playerStartPosition;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            lives = 5;
        }
    }
}
