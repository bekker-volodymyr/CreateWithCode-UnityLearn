using System.Collections.Generic;
using UnityEngine;

namespace Prototype2
{
    public class AnimalFactory
    {
        private readonly Dictionary<string, ObjectPool<PoolableObject>> _pools = new();

        public AnimalFactory(PoolableObject[] prefabs)
        {
            foreach (var prefab in prefabs)
            {
                _pools[prefab.name] = new ObjectPool<PoolableObject>(prefab);
            }
        }

        public PoolableObject GetAnimal(string animalName)
        {
            if (_pools.TryGetValue(animalName, out var pool))
                return pool.GetObject();

            Debug.LogError($"Animal type '{animalName}' not found in factory!");
            return null;
        }

        public PoolableObject GetRandomAnimal()
        {
            var keys = new List<string>(_pools.Keys);
            var randomKey = keys[Random.Range(0, keys.Count)];
            return GetAnimal(randomKey);
        }
    }
}
