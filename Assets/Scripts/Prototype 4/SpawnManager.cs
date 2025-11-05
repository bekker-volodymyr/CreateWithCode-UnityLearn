using UnityEngine;

namespace Prototype4
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _enemyPrefab;
        [SerializeField]
        private GameObject _powerUpPrefab;

        [SerializeField]
        private float _randomRange = 9f;

        private int _enemyCount;
        private int _waveNumber = 1;

        void Start()
        {
            SpawnEnemyWave(_waveNumber);
        }

        void Update()
        {
            // Bad practice - FindObjectType is a high cost operation            
            // _enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

            if (_enemyCount == 0)
            {
                SpawnEnemyWave(++_waveNumber);
            }
        }

        private void SpawnEnemy()
        {
            Enemy enemy = Instantiate(_enemyPrefab, GetRandomPosition(), Quaternion.identity).GetComponent<Enemy>();
            _enemyCount++;
            enemy.DeathEvent += () => _enemyCount--;
        }

        private void SpawnEnemyWave(int count)
        {
            for (int i = 0; i < count; i++)
            {
                SpawnEnemy();
            }
            Instantiate(_powerUpPrefab, GetRandomPosition(), Quaternion.identity);
        }

        private Vector3 GetRandomPosition()
        {
            float posX = Random.Range(-_randomRange, _randomRange);
            float posZ = Random.Range(-_randomRange, _randomRange);
            return new Vector3(posX, 0f, posZ);
        }
    }
}