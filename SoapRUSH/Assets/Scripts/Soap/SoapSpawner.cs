using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

namespace Soap
{
    public class SoapSpawner : MonoBehaviour
    {
        [SerializeField] private Spawn RedPrefab;
        [SerializeField] private Spawn CyanPrefab;
        [SerializeField] private Spawn _tempObj;
        private Spawn _obj;
        private GameObject deletableObj;
        
        [SerializeField] 
        private float SpawnDurationInSeconds = 2;

        private ThrowSoap _spawnShooter;

        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;

        private bool clicked;
        private bool canSpawn;
        
    
        private void Start()
        {
            _spawnShooter = GetComponent<ThrowSoap>();

            InitialiseLevel();

            btn1 = GameObject.FindGameObjectWithTag("btn1").GetComponent<Button>();
            btn1.onClick.AddListener(SpawnBttn1);
            btn2 = GameObject.FindGameObjectWithTag("btn2").GetComponent<Button>();
            btn2.onClick.AddListener(SpawnBttn2);
            btn3 = GameObject.FindGameObjectWithTag("btn3").GetComponent<Button>();
            btn4 = GameObject.FindGameObjectWithTag("btn4").GetComponent<Button>();
        }
        
        public void SpawnBttn1()
        {
            
            if (deletableObj != null && !_spawnShooter.isShot)
                Destroy(deletableObj);
            
            if (canSpawn) {
                _obj = Instantiate(RedPrefab, transform.position, transform.rotation);
                deletableObj = _obj.gameObject;
                _spawnShooter.ChangeCurrentSpawn(_obj.GetComponent<Spawn>());
            }
        }
        
        public void SpawnBttn2()
        {
            
            if (deletableObj != null && !_spawnShooter.isShot)
                Destroy(deletableObj);
            
            if (canSpawn)
            {
                _obj = Instantiate(CyanPrefab, transform.position, transform.rotation);
                deletableObj = _obj.gameObject;
                _spawnShooter.ChangeCurrentSpawn(_obj.GetComponent<Spawn>());
            }
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<Spawn>())
            {
                deletableObj = other.gameObject;
            }
        }

        public void NewSpawn()
        {
            _spawnShooter.ChangeCurrentSpawn(Instantiate(deletableObj, transform.position, transform.rotation).GetComponent<Spawn>());
            //_spawnShooter.ChangeCurrentSpawn(_tempObj.GetComponent<Spawn>());
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Spawn>())
            {
                //Instantiate(deletableObj, transform.position, transform.rotation);
                canSpawn = true;
                //Invoke(nameof(NewSpawn), SpawnDurationInSeconds);
                
            }
        }

        private void InitialiseLevel()
        {
            //Instantiate(_tempObj, transform.position, transform.rotation);
            _obj = Instantiate(_tempObj, transform.position, transform.rotation);
            _spawnShooter.ChangeCurrentSpawn(_obj.GetComponent<Spawn>());
        }
        
        
    }
}
