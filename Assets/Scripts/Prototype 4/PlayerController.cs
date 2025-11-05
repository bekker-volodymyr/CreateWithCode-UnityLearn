using System.Collections;
using UnityEngine;

namespace Prototype4
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 5f;
        [SerializeField]
        private float _powerUpStrength = 50f;

        [SerializeField]
        private GameObject _powerUpIndicator;
        [SerializeField]
        private Vector3 _indicatorOffset = new Vector3(0f, -0.2f, 0f);

        private Rigidbody _rb;

        private float _fwdInput;

        private GameObject _focalPoint;

        private bool _hasPowerUp = false;

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _focalPoint = GameObject.Find("Focal Point");
        }

        void Update()
        {
            _fwdInput = Input.GetAxis("Vertical");

            // _rb.AddForce(Vector3.forward * _speed * _fwdInput);
            _rb.AddForce(_focalPoint.transform.forward * _speed * _fwdInput);

            _powerUpIndicator.transform.position = transform.position + _indicatorOffset;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PowerUp"))
            {
                _hasPowerUp = true;
                _powerUpIndicator.SetActive(true);
                StartCoroutine(PowerUpCountdownRoutine());
                Destroy(other.gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && _hasPowerUp)
            {
                Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

                Vector3 awayDir = (collision.gameObject.transform.position - transform.position).normalized;

                enemyRb.AddForce(awayDir * _powerUpStrength, ForceMode.Impulse);

                Debug.Log($"Collision with enemy. Power up set to {_hasPowerUp}");
            }
        }

        private IEnumerator PowerUpCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            _hasPowerUp = false;
            _powerUpIndicator.SetActive(false);
        }
    }
}