using System;
using System.Collections;
using UnityEngine;

namespace LikeADoom
{
    public class DistanceChecker : MonoBehaviour
    {
        [SerializeField] private float[] _distances;
        [SerializeField] private float _delayBetweenChecksSeconds;

        private static readonly Color[] _distanceColors = { Color.red, Color.yellow, Color.green, Color.cyan };

        private Transform _target;
        private Distance _current = Distance.ExtremelyFar;
        
        public enum Distance
        {
            Closest,
            Close,
            Medium,
            Far,
            ExtremelyFar,
        }
        
        public event Action<Distance> OnReachDistance;

        private void OnValidate()
        {
            if (_distances.Length > 4)
                throw new ArgumentException("No support for 5 and more distances!");
        }

        public void Initialize(Transform target)
        {
            _target = target;
        }

        public void StartChecking()
        {
            StartCoroutine(CheckRoutine());
        }

        private IEnumerator CheckRoutine()
        {
            while (true)
            {
                Distance newDistance = Check();
                if (_current != newDistance)
                {
                    _current = newDistance;
                    OnReachDistance?.Invoke(newDistance);
                }
                yield return new WaitForSeconds(_delayBetweenChecksSeconds);
            }
        }

        private Distance Check()
        {
            float distance = Vector3.Distance(transform.position, _target.position);
            for (int i = 0; i < _distances.Length; i++)
                if (distance < _distances[i])
                    return (Distance)i;

            return (Distance)_distances.Length;
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; i < _distances.Length; i++)
            {
                Gizmos.color = _distanceColors[i];
                Gizmos.DrawWireSphere(transform.position, _distances[i]);
            }
        }
    }
}