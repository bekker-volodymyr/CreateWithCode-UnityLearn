using UnityEngine;
using UnityEngine.InputSystem;

namespace Prototype1
{
    enum InputType
    {
        InputManager, InputSystem
    }

    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 5.0f;
        [SerializeField]
        private float _turnSpeed = 3.5f;

        private float _horInput;
        private float _fwdInput;

        [SerializeField]
        private InputType _inputType;

        private InputAction _moveAction;

        private Vector2 _moveInput;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _moveAction = InputSystem.actions.FindAction("Move");
            _moveAction.performed += OnMove;
            _moveAction.canceled += OnMove;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
        }

        // Update is called once per frame
        void Update()
        {
            // transform.Translate(0, 0, 1f);
            if (_inputType == InputType.InputManager)
            {
                _horInput = Input.GetAxis("Horizontal");
                _fwdInput = Input.GetAxis("Vertical");

                transform.Translate(Vector3.forward * Time.deltaTime * _speed * _fwdInput);
                //transform.Translate(Vector3.right * Time.deltaTime * _turnSpeed * _horInput);
                transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _horInput);
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * _speed * _moveInput.y);
                transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _moveInput.x);
            }
        }
    }
}
