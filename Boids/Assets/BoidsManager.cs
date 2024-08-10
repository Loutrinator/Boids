using System;
using System.Collections.Generic;
using UnityEngine;

namespace Boids
{
    public class BoidsManager : MonoBehaviour
    {
        [SerializeField]
        private int _boidsQuantity = 50;

        [SerializeField]
        private Vector2 _boidsSpawnRangeX;
        [SerializeField]
        private Vector2 _boidsSpawnRangeY;
        [SerializeField]
        private Vector2 _boidsSpawnRangeZ;

        [SerializeField]
        private Boid _boidPrefab = null;

        private List<Boid> _allBoids = null;

        public List<Boid> AllBoids => _allBoids;

        private void Start()
        {
            _allBoids = new List<Boid>();
            for (int i = 0; i < _boidsQuantity; i++)
            {
                float x = UnityEngine.Random.Range(_boidsSpawnRangeX.x, _boidsSpawnRangeX.y);
                float y = UnityEngine.Random.Range(_boidsSpawnRangeY.x, _boidsSpawnRangeY.y);
                float z = UnityEngine.Random.Range(_boidsSpawnRangeZ.x, _boidsSpawnRangeZ.y);
                Vector3 pos = new Vector3(x,y,z);
                Quaternion rot = Quaternion.Euler(UnityEngine.Random.Range(0.0f, 360.0f), UnityEngine.Random.Range(0.0f, 360.0f), UnityEngine.Random.Range(0.0f, 360.0f));
                Boid boid = Instantiate(_boidPrefab,pos, rot);
                _allBoids.Add(boid);
                boid.SetBoidManager(this);
            }
        }
    }
}
