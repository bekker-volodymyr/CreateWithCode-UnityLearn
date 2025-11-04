using UnityEngine;

namespace Prototype3
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody _rb;

        [SerializeField]
        private float _jumpForce = 10f;
        [SerializeField]
        private float _gravityModifier = 1.5f;

        private bool _isGrounded = true;
        public bool _isGameOver = false;

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            Physics.gravity *= _gravityModifier;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _isGrounded = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                _isGameOver = true;
                Debug.Log("GAME OVER!");
            }
        }
    }
}