using System;
using UnityEngine;
using Soap;

namespace DirtyMesh
{
    public class CleanDirtyMesh : MonoBehaviour
    {
        private MeshFilter _meshFilter;
        private Mesh _planeMesh;
        public Vector3[] _vertices;


        [SerializeField] private float _radius;
        [SerializeField] private float _power;

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
                }
            }

            _planeMesh.vertices = _vertices;
            
        }
    }
}