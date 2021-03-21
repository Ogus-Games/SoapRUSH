using System;
using System.Security.Cryptography;
using DirtyMesh;
using UnityEngine;
using UnityEngine.UI;

namespace Soap
{
    public class SoapSpawner : MonoBehaviour
    {
        [SerializeField] private Spawn RedSoap;
        [SerializeField] private Spawn GreenSoap;
        [SerializeField] private Spawn PurpleSoap;
        //[SerializeField] private Spawn OgusSoap;
        [SerializeField] private Spawn _tempObj;
        private Spawn _obj = null;
        private GameObject deletableObj;
        
        [SerializeField] 
        private float SpawnDurationInSeconds = 2;

        private ThrowSoap _spawnShooter;
        private CountManager _countManager;
        private CleanDirtyMesh _meshManager;
        
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;

        private bool clicked;
        private bool canSpawn;

        private AudioSource _soapSelectAudio;
        
        private void Start()
        {
            _spawnShooter = GetComponent<ThrowSoap>();
            _countManager = FindObjectOfType<CountManager>();
            _meshManager = FindObjectOfType<CleanDirtyMesh>();
            _soapSelectAudio = GameObject.FindGameObjectWithTag("soapSelectAudio").GetComponent<AudioSource>();
            
            InitialiseLevel();
            
            btn1 = GameObject.FindGameObjectWithTag("btn1").GetComponent<Button>();
            btn1.onClick.AddListener(SpawnBttn1);
            btn2 = GameObject.FindGameObjectWithTag("btn2").GetComponent<Button>();
            btn2.onClick.AddListener(SpawnBttn2);
            btn3 = GameObject.FindGameObjectWithTag("btn3").GetComponent<Button>();
            btn3.onClick.AddListener(SpawnBttn3);
            btn4 = GameObject.FindGameObjectWithTag("btn4").GetComponent<Button>();
            //btn4.onClick.AddListener(SpawnBttn4);
        }
        
        public void SpawnBttn1()
        {
            
            if (deletableObj != null && !_spawnShooter.isShot)
                Destroy(deletableObj);
            
            if (canSpawn && _countManager.btn1RemainingUsage > 0)
            {
                _soapSelectAudio.Play();
                _meshManager._radius = 2;
                _countManager.btn1RemainingUsage--;
                _obj = Instantiate(RedSoap, transform.position, transform.rotation);
                deletableObj = _obj.gameObject;
                _spawnShooter.ChangeCurrentSpawn(_obj.GetComponent<Spawn>());
            }
        }
        
        public void SpawnBttn2()
        {
            
            if (deletableObj != null && !_spawnShooter.isShot)
                Destroy(deletableObj);
            
            if (canSpawn && _countManager.btn2RemainingUsage > 0)
            {
                _soapSelectAudio.Play();
                _meshManager._radius = 4;
                _countManager.btn2RemainingUsage--;
                _obj = Instantiate(GreenSoap, transform.position, transform.rotation);
                deletableObj = _obj.gameObject;
                _spawnShooter.ChangeCurrentSpawn(_obj.GetComponent<Spawn>());
            }
        }
        
        public void SpawnBttn3()
        {
            
            if (deletableObj != null && !_spawnShooter.isShot)
                Destroy(deletableObj);
            
            if (canSpawn && _countManager.btn3RemainingUsage > 0)
            {
                _soapSelectAudio.Play();
                _meshManager._radius = 4;
                _countManager.btn3RemainingUsage--;
                _obj = Instantiate(PurpleSoap, transform.position, transform.rotation);
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
