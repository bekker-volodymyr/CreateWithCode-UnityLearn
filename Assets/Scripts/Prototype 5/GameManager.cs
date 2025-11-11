using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype5
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _prefabs;

        [SerializeField]
        private float _spawnRate = 1f;

        void Start()
        {
            StartCoroutine(SpawnObjects());
        }

        private IEnumerator SpawnObjects()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnRate);
                Instantiate(_prefabs[Random.Range(0, _prefabs.Count)]);
            }
        }
    }
}