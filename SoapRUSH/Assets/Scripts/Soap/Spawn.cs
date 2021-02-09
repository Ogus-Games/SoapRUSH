using System;
using UnityEngine;

namespace Soap
{
    public class Spawn : MonoBehaviour
    {
        [SerializeField] private string _stickTag;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(_stickTag))
            {
                _rigidbody.isKinematic = true;
            }
            else
            {
                _rigidbody.useGravity = true;
            }
        }

        public void MoveWithVelocity(Vector3 velocity)
        {
            _rigidbody.velocity = velocity;
        }
    }
}