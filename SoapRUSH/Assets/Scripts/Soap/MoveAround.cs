using UnityEngine;

namespace Assets.Scripts.Soap
{
    public class MoveAround : MonoBehaviour
    {
        [SerializeField] private float _turnSpeed;

        private ThrowSoap _spawnManager; 
        private void Start()
        {
            _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ThrowSoap>();
        }

        private void Update()
        {
            if (_spawnManager.isShot)
                RotateAround();
        }

        public void RotateAround()
        {
            this.transform.Rotate(Vector3.forward+Vector3.up, _turnSpeed*Time.deltaTime);
            
        }
        
    }
}
