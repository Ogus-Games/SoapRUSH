using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace DirtyMesh
{
    public class DirtyMeshManager : MonoBehaviour
    {
        [SerializeField] private Vector3[] _dirtyMesh;
        [SerializeField] private List<Vector3> _verticesArr;

        private int _count;

        public bool finished;
        
        private void Start()
        {
            _dirtyMesh = GameObject.FindGameObjectWithTag("Stick").GetComponent<CleanDirtyMesh>()._vertices;
            GetArray();
        }

        private void LateUpdate()
        {
            _dirtyMesh = GameObject.FindGameObjectWithTag("Stick").GetComponent<CleanDirtyMesh>()._vertices;
            StartCoroutine(CheckLevel());
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
                Time.timeScale = 0;
            }
            yield return new WaitForSeconds(2);
        }
        
        
    }
}