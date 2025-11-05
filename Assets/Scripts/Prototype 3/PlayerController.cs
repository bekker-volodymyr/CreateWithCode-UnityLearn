using UnityEngine;

namespace Prototype3
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody _rb;
        private Animator _animator;
        private AudioSource _audioSource;

        [SerializeField]
        private ParticleSystem _explosionParticle;
        [SerializeField]
        private ParticleSystem _dirtParticle;

        [SerializeField]
        private AudioClip _jumpSound;
        [SerializeField]
        private AudioClip _crashSound;

        [SerializeField]
        private float _jumpForce = 10f;
        [SerializeField]
        private float _gravityModifier = 1.5f;

        private bool _isGrounded = true;
        public bool _isGameOver = false;

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();

            Physics.gravity *= _gravityModifier;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && !_isGameOver)
            {
                _animator.SetTrigger("Jump_trig");
                _audioSource.PlayOneShot(_jumpSound, 1.0f);
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _isGrounded = false;
                _dirtParticle.Stop();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
                _dirtParticle.Play();
            }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                _isGameOver = true;
                _explosionParticle.Play();
                _dirtParticle.Stop();
                _audioSource.PlayOneShot(_crashSound, 1.0f);
                _animator.SetBool("Death_b", true);
                _animator.SetInteger("DeathType_int", 1);
                Debug.Log("GAME OVER!");
            }
        }
    }
}