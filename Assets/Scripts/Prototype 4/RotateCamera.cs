using UnityEngine;

namespace Prototype4
{
    public class RotateCamera : MonoBehaviour
    {
        [SerializeField]
        private float _rotateSpeed = 20f;

        private float _horInput;

        void Update()
        {
            _horInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime * _horInput);
        }
    }
}