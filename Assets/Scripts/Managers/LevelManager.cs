using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public int adCount = 0;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        adCount = 0;
    }

    public void AdButton()
    {
        if (adCount == 0) { AdManager.Instance.ShowAd(this); }
        
        adCount++;
    }

    public void RetryButton()
    {
        if (PlayerPrefs.GetInt("Score") < ScoreManager.Instance.score)
        {
            PlayerPrefs.SetInt("Score", ScoreManager.Instance.score);
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}