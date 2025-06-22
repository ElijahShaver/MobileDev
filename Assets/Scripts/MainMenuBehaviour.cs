using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene
using TMPro;

public class MainMenuBehaviour : MonoBehaviour
{
    public TMP_Text highScoreText;

    /// <summary>
    /// Will load a new scene upon being called
    /// </summary>
    /// <param name="levelName">The name of the level
    /// we want to go to</param>
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("score", 0);
        GetAndDisplayScore();
    }

    private void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("score");
    }

    private void GetAndDisplayScore()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("score").ToString();
    }
}