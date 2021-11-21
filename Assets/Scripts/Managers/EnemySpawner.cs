using System.Collections;
using UnityEngine;

namespace Managers
{
    public class EnemySpawner : MonoBehaviour
    {
        public static EnemySpawner Instance;

        [SerializeField] GameObject[] enemies;
        public float spawnSpeed = 3f;

        private void Awake()
        {
            Instance = this;
        }

        // Update is called once per frame
        void Start()
        {
            StartCoroutine(nameof(SpawnEnemy));
        }

        IEnumerator SpawnEnemy()
        {
            var platform = Instantiate(enemies[Random.Range(0, enemies.Length)], this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnSpeed);
            StartCoroutine(nameof(SpawnEnemy));
        }
    }
}