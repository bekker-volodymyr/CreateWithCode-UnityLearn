using UnityEngine;

namespace Prototype5
{
    public class Target : MonoBehaviour
    {
        private Rigidbody _rb;

        [SerializeField]
        private float _minSpeed = 10f;
        [SerializeField]
        private float _maxSpeed = 14f;

        [SerializeField]
        private float _torqueRange = 7;

        [SerializeField]
        private float _xRange = 4f;
        [SerializeField]
        private float _yPos = -1f;

        [SerializeField]
        private int _pointValue;

        [SerializeField]
        private ParticleSystem _explosionEffect;

        private GameManager _gameManager;

        void Start()
        {
            _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

            _rb = GetComponent<Rigidbody>();

            transform.position = GetSpawnPosition();

            _rb.AddForce(GetRandomForce(), ForceMode.Impulse);
            _rb.AddTorque(GetRandomTorque(), GetRandomTorque(), GetRandomTorque(), ForceMode.Impulse);
        }

        private void OnMouseDown()
        {
            if (!_gameManager.IsGameActive) return;

            _gameManager.UpdateScore(_pointValue);
            Instantiate(_explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
            if (!gameObject.CompareTag("Bad"))
            {
                _gameManager.GameOver();
            }
        }

        private Vector3 GetSpawnPosition()
        {
            float xPos = Random.Range(-_xRange, _xRange);
            return new Vector3(xPos, _yPos, 0f);
        }

        private Vector3 GetRandomForce()
        {
            return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
        }

        private float GetRandomTorque()
        {
            return Random.Range(-_torqueRange, _torqueRange);
        }
    }
}