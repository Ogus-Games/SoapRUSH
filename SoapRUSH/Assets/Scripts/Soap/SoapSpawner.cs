using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

namespace Soap
{
    public class SoapSpawner : MonoBehaviour
    {
        [SerializeField] private Spawn RedPrefab;
        [SerializeField] private Spawn CyanPrefab;

        private Spawn _obj;
        
        [SerializeField] 
        private float SpawnDurationInSeconds = 2;

        private ThrowSoap _spawnShooter;

        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;

        private bool clicked;
    
        private void Start()
        {
            _spawnShooter = GetComponent<ThrowSoap>();
            //NewSpawn();
            //SpawnBttn1();
            btn1 = GameObject.FindGameObjectWithTag("btn1").GetComponent<Button>();
            btn1.onClick.AddListener(SpawnBttn1);
            btn2 = GameObject.FindGameObjectWithTag("btn2").GetComponent<Button>();
            btn2.onClick.AddListener(SpawnBttn2);
            btn3 = GameObject.FindGameObjectWithTag("btn3").GetComponent<Button>();
            btn4 = GameObject.FindGameObjectWithTag("btn4").GetComponent<Button>();
        }

        public void SpawnBttn1()
        {
            if (_obj!=null)
                Destroy(_obj.gameObject);
            
            _obj = Instantiate(RedPrefab, transform.position, transform.rotation);
            _spawnShooter.ChangeCurrentSpawn(_obj.GetComponent<Spawn>());
        }

        public void SpawnBttn2()
        {
            if (_obj!=null)
                Destroy(_obj.gameObject);

            _obj = Instantiate(CyanPrefab, transform.position, transform.rotation);
            _spawnShooter.ChangeCurrentSpawn(_obj.GetComponent<Spawn>());
        }
        public void NewSpawn()
        {
            //_spawnShooter.ChangeCurrentSpawn(Instantiate(spawnPrefab, transform.position, transform.rotation).GetComponent<Spawn>());
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
