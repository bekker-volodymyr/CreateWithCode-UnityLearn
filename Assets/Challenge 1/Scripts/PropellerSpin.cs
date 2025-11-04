using UnityEngine;

namespace Challange1
{
    public class PropellerSpin : MonoBehaviour
    {
        [SerializeField]
        private float _turnSpeed = 25f;

        void Update()
        {
            transform.Rotate(Vector3.forward, _turnSpeed * Time.deltaTime);
        }
    }
}