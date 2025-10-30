using UnityEngine;

namespace Prototype2
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _animalPrefabs;

        [SerializeField]
        private float _spawnRangeX = 20.0f;
        [SerializeField]
        private float _spawnPosZ = 20f;

        [SerializeField]
        private float _startDelay = 2f;
        [SerializeField]
        private float _spawnInterval = 1.5f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InvokeRepeating("SpawnRandomAnimal", _startDelay, _spawnInterval);
        }

        // Update is called once per frame
        void Update()
        {
            //if (Input.GetKeyDown(KeyCode.S))
            //{
            //    SpawnRandomAnimal();
            //}
        }

        private void SpawnRandomAnimal()
        {
            int animalIndex = Random.Range(0, _animalPrefabs.Length);
            Vector3 spawnPos = new Vector3(
                Random.Range(-_spawnRangeX, _spawnRangeX),
                0f, _spawnPosZ);
            Instantiate(_animalPrefabs[animalIndex],
                spawnPos,
                _animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
