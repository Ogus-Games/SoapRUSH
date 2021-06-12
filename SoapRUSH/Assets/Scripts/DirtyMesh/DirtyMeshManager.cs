using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.DirtyMesh
{
    public class DirtyMeshManager : MonoBehaviour
    {
        [SerializeField] private Vector3[] _dirtyMesh;
        [SerializeField] private List<Vector3> _verticesArr;

        public bool levelFinished;
        public bool finished;
        private LevelManager _levelManager;

        private CountManager _countManager;
        private CleanDirtyMesh _throwManager;
        private StarHandler _starHandler;

        private int _count;
        
        private void Start()
        {
            _dirtyMesh = GameObject.FindGameObjectWithTag("Stick").GetComponent<CleanDirtyMesh>()._vertices;
            _levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
            
            _countManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CountManager>();
            _throwManager = GameObject.FindGameObjectWithTag("Stick").GetComponent<CleanDirtyMesh>();
            _starHandler = GameObject.FindGameObjectWithTag("starManager").GetComponent<StarHandler>();
            
            GetArray();
        }

        private void LateUpdate()
        {
            if (!levelFinished)
            {
                _dirtyMesh = GameObject.FindGameObjectWithTag("Stick").GetComponent<CleanDirtyMesh>()._vertices;
                StartCoroutine(CheckLevel());
            }
            //else
            //    _levelManager.ContinueToNewScene(); // !!!Burada yeni menu acilacak, menuden diger levela gecilecek!!!
            
        }

        private void GetArray()
        {
            //Array.Resize<>(ref _verticesArr,_dirtyMesh.Length);
            for (int i = 0; i < _dirtyMesh.Length; i++)
            {
                _verticesArr.Add(_dirtyMesh[i]);
            }
        }

        private IEnumerator CheckLevel()
        {
            _count = 0;
            for (int i = 0; i < _verticesArr.Count; i++)
            {
                
                if (_verticesArr[i].z != _dirtyMesh[i].z)
                {
                    finished = true;
                    _count++;
                    
                }
                //Debug.Log("Finished? " + finished);
                
            }
            
            if (_count==_dirtyMesh.Length)
            {
                Debug.Log("OYUN BITTIIII");
                
                yield return new WaitForSeconds(1f);
                levelFinished = true;
            }
            else
            {
                if (_countManager.count == 0 && _throwManager.canThrown && !levelFinished)
                {
                    yield return new WaitForSeconds(1f);
                    _countManager.failMenu.SetActive(true);
                    _starHandler.menuIsOpen = true;
                    AdManager.instance.ShowInterstitial();
                }
            }
            yield return new WaitForSeconds(2);
        }
        
        
    }
}