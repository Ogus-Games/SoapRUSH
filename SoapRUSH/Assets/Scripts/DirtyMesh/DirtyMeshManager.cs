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

        private int _count;
        
        private void Start()
        {
            _dirtyMesh = GameObject.FindGameObjectWithTag("Stick").GetComponent<CleanDirtyMesh>()._vertices;
            _levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
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
                
                // animation can be implemented here
                // Win anim with stars which are based on usage of soaps
                yield return new WaitForSeconds(1f);
                levelFinished = true;
                
                //_levelManager.levelNumber++;
                //_levelManager.ContinueToNewScene();
            }
            yield return new WaitForSeconds(2);
        }
        
        
    }
}