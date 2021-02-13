using System;
using DirtyMesh;
using UnityEngine;

namespace Soap
{
    public class Spawn : MonoBehaviour
    {
        [SerializeField] private string _stickTag;

        private Rigidbody _rigidbody;

        private CleanDirtyMesh _cleaner;
        private Vector3 _hitPoint;

        private ThrowSoap _thrower;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _thrower = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ThrowSoap>();
            _cleaner = GameObject.FindGameObjectWithTag("Stick").GetComponent<CleanDirtyMesh>();
        }

        private void OnCollisionEnter(Collision other)
        {   // This is where soap touches with the mesh which has a tag that named "Stick" 
            if (other.gameObject.CompareTag(_stickTag)) 
            {
                _rigidbody.isKinematic = true;
                Destroy(this.gameObject);
                _cleaner.DeformThisPlane(_thrower.hitPoint);
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