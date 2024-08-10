using UnityEngine;

namespace Boids
{
    [CreateAssetMenu(fileName = "BoidParameters", menuName = "ScriptableObjects/BoidParameters", order = 1)]
    public class BoidParameters : ScriptableObject
    {
        [SerializeField]
        private float _boidsMovingSpeed = 5f;
        [SerializeField]
        private float _boidsNeighbourDistance = 3f;
        [SerializeField, Range(-1f, 1f)]
        private float _boidsViewRange = -0.5f;

        public float NeighbourDistance => _boidsNeighbourDistance;
        public float BoidsViewRange => _boidsViewRange;
        public float BoidsMovingSpeed => _boidsMovingSpeed;
    }
}
