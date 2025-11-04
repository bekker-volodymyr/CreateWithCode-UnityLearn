using UnityEngine;

namespace Prototype3
{
    public class MoveLeft : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 20f;

        private PlayerController _player;

        [SerializeField]
        private float _leftBound = -15f;

        private void Start()
        {
            _player = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        void Update()
        {
            if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
                Destroy(gameObject);

            if (!_player._isGameOver)
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
    }
}