using Boids;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace Boids
{
    public class Boid : MonoBehaviour
    {
        [SerializeField]
        private BoidParameters _boidsParameters;
        private BoidsManager _manager;
        private List<Boid> _neighbours = null;
        private Vector3 _direction = Vector3.forward;
        internal void SetBoidManager(BoidsManager boidsManager)
        {
            _manager = boidsManager;
        }
        void Update()
        {
            UpdateNeighbours();

            UpdateDirection();
            MoveToDirection();
        }

        private void UpdateDirection()
        {
            _direction = transform.forward;
        }

        private void MoveToDirection()
        {
            transform.position += _direction * (_boidsParameters.BoidsMovingSpeed * Time.deltaTime);
        }

        private void UpdateNeighbours()
        {
            _neighbours = _manager.AllBoids.FindAll(b =>
            {
                Vector3 direction = this.transform.position - b.transform.position;
                return direction.magnitude <= _boidsParameters.NeighbourDistance && Vector3.Dot(transform.forward, direction.normalized) >= _boidsParameters.BoidsViewRange;
            }).ToList();
        }
    }
}
