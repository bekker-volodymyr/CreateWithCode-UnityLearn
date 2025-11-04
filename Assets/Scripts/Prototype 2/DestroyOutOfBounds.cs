using Prototype2;
using UnityEngine;

[RequireComponent(typeof(PoolableObject))]
public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField]
    private float _topBound = 30f;
    [SerializeField]
    private float _lowerBound = -10.0f;

    private PoolableObject _poolable;

    private void Start()
    {
        _poolable = GetComponent<PoolableObject>();
    }

    void Update()
    {
        if (transform.position.z > _topBound)
        {
            _poolable.ReturnCallback.Invoke();
            // Destroy(gameObject);
        }
        else if (transform.position.z < _lowerBound)
        {
            // Destroy(gameObject);
            _poolable.ReturnCallback.Invoke();
            Debug.Log("GAME OVER");
        }
    }
}
