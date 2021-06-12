using System.Collections;
using Assets.Scripts.Managers;
using Assets.Scripts.Soap;
using UnityEngine;

namespace Assets.Scripts.DirtyMesh
{
    public class CleanDirtyMesh : MonoBehaviour
    {
        private MeshFilter _meshFilter;
        private Mesh _planeMesh;
        public Vector3[] _vertices;
        public bool canThrown = true;
        private AudioSource _collisionAudio;

        [SerializeField] public float _radius;
        [SerializeField] public float _power;

        public bool isTouched;

        private CountManager _countManager;
        private SoapSpawner _spawnManager;
        private DirtyMeshManager _dirtyMeshManager;
        private StarHandler _starHandler;
        private void Awake()
        {
            _meshFilter = GetComponent<MeshFilter>();
            _planeMesh = _meshFilter.mesh;
            _vertices = _planeMesh.vertices;
        }

        private void Start()
        {
            _meshFilter = GetComponent<MeshFilter>();
            _planeMesh = _meshFilter.mesh;
            _vertices = _planeMesh.vertices;

            _collisionAudio = GameObject.FindGameObjectWithTag("CollideAudio").GetComponent<AudioSource>();
            
            _dirtyMeshManager = GameObject.FindGameObjectWithTag("meshManager").GetComponent<DirtyMeshManager>();
            _countManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CountManager>();
            _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SoapSpawner>();
            _starHandler = GameObject.FindGameObjectWithTag("starManager").GetComponent<StarHandler>();
        }

        public void DeformThisPlane(Vector3 PositionToDeform)
        {
            PositionToDeform = transform.InverseTransformPoint(PositionToDeform);
            for (int i = 0; i < _vertices.Length; i++)
            {
                float dist = (_vertices[i] - PositionToDeform).sqrMagnitude;
                
                if (dist < _radius) // Deletion of vertices might be done here!
                {
                    _vertices[i] -= Vector3.back * _power;
                    _collisionAudio.Play();
                }
                
            }
            
            _planeMesh.vertices = _vertices;
            canThrown = true;
            
        }
    }
}