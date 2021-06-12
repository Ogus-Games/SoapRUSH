using Assets.Scripts.DirtyMesh;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Soap
{
    public class ThrowSoap : MonoBehaviour
    {

        [SerializeField] 
        private float FlightDurationInSeconds = 2;

        private Spawn _currentSpawn;
        private Camera _mainCamera;
        public bool isShot;
        public Vector3 hitPoint;

        private AudioSource _throwAudio;
        private CleanDirtyMesh _throwManager;
        private StarHandler _starHandler;
        private SoapSpawner _soapSpawner;
        private CountManager _countManager;
        
        private void Start()
        {
            _mainCamera = Camera.main;
            _throwAudio = GameObject.FindGameObjectWithTag("ThrowAudio").GetComponent<AudioSource>();
            _throwManager = GameObject.FindGameObjectWithTag("Stick").GetComponent<CleanDirtyMesh>();
            _starHandler = GameObject.FindGameObjectWithTag("starManager").GetComponent<StarHandler>();
            _countManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CountManager>();
            _soapSpawner = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SoapSpawner>();
        }

        public void ChangeCurrentSpawn(Spawn newSpawn)
        {
            _currentSpawn = newSpawn;
            isShot = false;
        }
           
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (isShot) return;
                //RotateTowardsTarget();
                if (!_starHandler.menuIsOpen && _throwManager.canThrown && _soapSpawner.deletableObj != null)
                {
                    Shoot();    
                }
                
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
                _throwManager.canThrown = false;
                ShootWithVelocity(hit.point);
                hitPoint = hit.point;
                if (_soapSpawner.state == SoapSpawner.whichSoap.RED)
                {
                    _countManager.btn1RemainingUsage--;
                }
                else if (_soapSpawner.state == SoapSpawner.whichSoap.GREEN)
                {
                    _countManager.btn2RemainingUsage--;
                }
                else if (_soapSpawner.state == SoapSpawner.whichSoap.PURPLE)
                {
                    _countManager.btn3RemainingUsage--;
                }
            }
        }

        private void ShootWithVelocity(Vector3 targetPosition)
        {
            _currentSpawn.MoveWithVelocity( (targetPosition - _currentSpawn.transform.position) / FlightDurationInSeconds);
            _throwAudio.Play();
            isShot = true;
        }
    }
}