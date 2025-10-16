using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RetrySceneManager : MonoBehaviour
{
    public TMP_Text lifeText;
    public Button retryButton;
    public Button quitButton;

    void Start()
    {
        // Update lives count
        lifeText.text = "Lives Remaining: " + GameManager.instance.lives;

        // Button listeners
        retryButton.onClick.AddListener(() =>
        {
            GameManager.instance.RetryLevel();
        });

        quitButton.onClick.AddListener(() =>
        {
            GameManager.instance.QuitGame();
        });
    }
}
