using UnityEngine;
using UnityEngine.UI;

namespace Managers
{

    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;
        [SerializeField] private Text scoreText;
        public int score = 0;

        // Start is called before the first frame update
        private void Awake()
        {
            Instance = this;
            score = 0;
        }

        // Update is called once per frame
        private void Update()
        {
            scoreText.text = score.ToString();

            if (score > 5000)
            {
                return;
            }

            if (score < 500)
            {
                EnemySpawner.Instance.spawnSpeed = 3f;
                PlatformSpawner.Instance.spawnSpeed = 5f;
            }
            else if (score > 500 && score < 1000)
            {
                EnemySpawner.Instance.spawnSpeed = 2f;
                PlatformSpawner.Instance.spawnSpeed = 4f;
            }
            else if (score > 1000 && score < 2000)
            {
                EnemySpawner.Instance.spawnSpeed = 1f;
                PlatformSpawner.Instance.spawnSpeed = 3f;
            }
            else if (score > 2000 && score < 3000)
            {
                EnemySpawner.Instance.spawnSpeed = .5f;
                PlatformSpawner.Instance.spawnSpeed = 3f;
            }
            else if (score > 3000 && score < 4000)
            {
                EnemySpawner.Instance.spawnSpeed = .25f;
                PlatformSpawner.Instance.spawnSpeed = 3f;
            }
            else if (score > 4000 && score < 5000)
            {
                EnemySpawner.Instance.spawnSpeed = .1f;
                PlatformSpawner.Instance.spawnSpeed = 3f;
            }
        }
    }
}