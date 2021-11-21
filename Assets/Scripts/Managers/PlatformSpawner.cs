using System.Collections;
using UnityEngine;

namespace Managers
{
    public class PlatformSpawner : MonoBehaviour
    {
        public static PlatformSpawner Instance;

        [SerializeField] GameObject[] platforms;
        public float spawnSpeed = 5f;

        private void Awake()
        {
            Instance = this;
        }

        // Update is called once per frame
        void Start()
        {
            StartCoroutine(nameof(SpawnPlatform));
        }

        IEnumerator SpawnPlatform()
        { 
            var platform = Instantiate(platforms[Random.Range(0, platforms.Length)], this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnSpeed);
            StartCoroutine(nameof(SpawnPlatform));
        }
    }
}