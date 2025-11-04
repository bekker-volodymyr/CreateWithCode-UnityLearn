using UnityEngine;

namespace Prototype2
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] PoolableObject[] _animalPrefabs;

        [SerializeField] private float _spawnRangeX = 20.0f;
        [SerializeField] private float _spawnPosZ = 20f;

        [SerializeField] private float _startDelay = 2f;
        [SerializeField] private float _spawnInterval = 1.5f;

        private AnimalFactory _factory;

        void Start()
        {
            _factory = new AnimalFactory(_animalPrefabs);
            InvokeRepeating(nameof(SpawnRandomAnimal), _startDelay, _spawnInterval);
        }

        private void SpawnRandomAnimal()
        {
            Vector3 spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0f, _spawnPosZ);
            var animal = _factory.GetRandomAnimal();
            animal.gameObject.transform.position = spawnPos;
            animal.gameObject.SetActive(true);
        }
    }
}
