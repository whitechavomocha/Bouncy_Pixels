using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] Text highScore;

        private void Awake()
        {
            Time.timeScale = 1.0f;
        }

        private void Start()
        {
            highScore.text = PlayerPrefs.GetInt("Score").ToString();
        }

        public void NextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        
    }
}