using UnityEngine;

namespace Soap
{
    public class SoapSpawner : MonoBehaviour
    {
        [SerializeField] 
        private Spawn SpawnPrefab;

        [SerializeField] 
        private float SpawnDurationInSeconds = 2;

        private ThrowSoap _spawnShooter;
    
        private void Start()
        {
            _spawnShooter = GetComponent<ThrowSoap>();
            NewSpawn();
        }

        public void NewSpawn()
        {
            _spawnShooter.ChangeCurrentSpawn(Instantiate(SpawnPrefab.gameObject, transform.position, transform.rotation).GetComponent<Spawn>());
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Spawn>())
            {
                Invoke(nameof(NewSpawn), SpawnDurationInSeconds);
            }
        }
    }
}
