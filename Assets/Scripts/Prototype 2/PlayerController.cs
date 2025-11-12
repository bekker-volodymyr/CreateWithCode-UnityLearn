using UnityEngine;

namespace Prototype2
{
    public class PlayerController : MonoBehaviour
    {
        private Animator _animator;

        [SerializeField]
        private PoolableObject _foodPrefab;

        [SerializeField]
        private float _speed = 15.0f;

        [SerializeField]
        private float _bound = 15.0f;

        private float _horInput;

        private ObjectPool<PoolableObject> _pool;

        void Start()
        {
            _pool = new ObjectPool<PoolableObject>(_foodPrefab);

            _animator = GetComponent<Animator>();
            _animator.SetFloat("Speed_f", 0);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Launch food");
                var food = _pool.GetObject();
                food.transform.position = transform.position;
                food.gameObject.SetActive(true);
                // Instantiate(_foodPrefab, transform.position, _foodPrefab.transform.rotation);
            }

            if (transform.position.x > _bound)
            {
                transform.position = new Vector3(_bound, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -_bound)
            {
                transform.position = new Vector3(-_bound, transform.position.y, transform.position.z);
            }

            _horInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.right * _speed * Time.deltaTime * _horInput);
        }
    }
}
