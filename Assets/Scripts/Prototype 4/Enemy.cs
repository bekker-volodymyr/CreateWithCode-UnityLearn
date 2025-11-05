using System;
using UnityEngine;

namespace Prototype4
{
    public class Enemy : MonoBehaviour
    {
        private Rigidbody _rb;
        private GameObject _player;

        [SerializeField]
        private float _speed = 4f;

        public event Action DeathEvent;

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _player = GameObject.Find("Player");
        }

        void Update()
        {
            Vector3 lookDir = (_player.transform.position - transform.position).normalized;

            _rb.AddForce(lookDir * _speed);

            if (transform.position.y < -10f)
            {
                DeathEvent.Invoke();
                Destroy(gameObject);
            }
        }
    }
}