using UnityEngine;

namespace Prototype2
{
    public class DetectCollisions : MonoBehaviour
    {
        private PoolableObject _poolable;

        private void Start()
        {
            _poolable = GetComponent<PoolableObject>();
        }

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<PoolableObject>().ReturnCallback.Invoke();
            _poolable.ReturnCallback.Invoke();
            // Destroy(other.gameObject);
            // Destroy(gameObject);
        }
    }
}
