using UnityEngine;

namespace Soap
{
    public class ThrowSoap : MonoBehaviour
    {

        [SerializeField] 
        private float FlightDurationInSeconds = 2;

        private Spawn _currentSpawn;
        private Camera _mainCamera;
        public bool _isShot;
        public Vector3 hitPoint;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        public void ChangeCurrentSpawn(Spawn newSpawn)
        {
            _currentSpawn = newSpawn;
            _isShot = false;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (_isShot) return;
                //RotateTowardsTarget();
                Shoot();
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
        
        private void Shoot()
        {
            RaycastHit hit;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                ShootWithVelocity(hit.point);
                hitPoint = hit.point;
            }
        }

        private void ShootWithVelocity(Vector3 targetPosition)
        {
            _currentSpawn.MoveWithVelocity( (targetPosition - _currentSpawn.transform.position) / FlightDurationInSeconds);
            _isShot = true;
        }
    }
}