using UnityEngine;

namespace Prototype3
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _prefab;

        [SerializeField]
        private Vector3 _spawnPos = new Vector3(25f, 0f, 0f);

        [SerializeField]
        private float _startDelay = 2f;
        [SerializeField]
        private float _repeatRate = 2f;

        private PlayerController _playerController;

        void Start()
        {
            InvokeRepeating(nameof(SpawnObstacle), _startDelay, _repeatRate);
            _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        private void SpawnObstacle()
        {
            if (!_playerController._isGameOver)
                Instantiate(_prefab, _spawnPos, _prefab.transform.rotation);
        }
    }
}