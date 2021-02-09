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
                
                RaycastHit hit;
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition); 
                if (Physics.Raycast(ray, out hit))
                {
                    ShootWithVelocity(hit.point);
                }
            }
        }

        private void ShootWithVelocity(Vector3 targetPosition)
        {
            _currentSpawn.MoveWithVelocity( (targetPosition - _currentSpawn.transform.position) / FlightDurationInSeconds);
            _isShot = true;
        }
    }
}