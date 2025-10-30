using UnityEngine;

namespace Prototype2
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _foodPrefab;

        [SerializeField]
        private float _speed = 15.0f;

        [SerializeField]
        private float _bound = 15.0f;

        private float _horInput;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Launch food");
                Instantiate(_foodPrefab, transform.position, _foodPrefab.transform.rotation);
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
