using System;
using Assets.Scripts.Soap;
using UnityEngine;

namespace Test
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private float FlightDurationInSeconds = 2;

        public Spawn _currentSpawn;

        private Camera _mainCamera;

        private bool _isShot;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        public void ChangeCurrentSpawn(Spawn NewSpawn)
        {
            _currentSpawn = NewSpawn;
            _isShot = false;
        }

        private void Update()
        {
            if (_isShot)
            {
                return;
            }

            if (Input.GetMouseButton(0))
            {
                RotateTowardsTarget();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ShootIt();
            }
            
        }

        public void RotateTowardsTarget()
        {
            RaycastHit hit;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                RotateTowardsMouse(hit.point);
            }
        }

        public void RotateTowardsMouse(Vector3 TargetPosition)
        {
            Vector3 DirectionVector = (TargetPosition - _currentSpawn.transform.position);
            _currentSpawn.transform.forward = DirectionVector;
        }

        public void ShootIt()
        {
            RaycastHit hit;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                ShootWithVelocity(hit.point);
            }
        }

        public void ShootWithVelocity(Vector3 TargetPosition)
        {
            Vector3 MovementVector = (TargetPosition - _currentSpawn.transform.position);
            _currentSpawn.MoveWithVelocity(MovementVector / FlightDurationInSeconds);

            _isShot = true;
        }
    }
}
