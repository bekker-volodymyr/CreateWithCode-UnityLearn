using System.Collections.Generic;
using UnityEngine;

namespace Prototype2
{
    public class ObjectPool<T> where T : PoolableObject
    {
        private T _prefab;

        private Queue<T> _objQueue;

        public ObjectPool(T prefab)
        {
            _prefab = prefab;
            _objQueue = new Queue<T>();
        }

        public PoolableObject GetObject()
        {
            T obj = _objQueue.Count > 0 ? _objQueue.Dequeue() : Object.Instantiate(_prefab);
            obj.ReturnCallback = () => { ReturnObject(obj); };
            return obj;
        }

        public void ReturnObject(T obj)
        {
            obj.gameObject.SetActive(false);
            _objQueue.Enqueue(obj);
        }
    }
}