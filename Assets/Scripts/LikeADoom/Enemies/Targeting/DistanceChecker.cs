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
        private Distance _current = Distance.OutOfRange;
        
        public enum Distance
        {
            Close,
            Medium,
            Far,
            OutOfRange,
        }
        
        public void SetTarget(Transform target) => _target = target;
        public Distance GetDistance() => _current;

        public void StartChecking() => StartCoroutine(CheckRoutine());
        private IEnumerator CheckRoutine()
        {
            while (true)
            {
                _current = GetCurrentDistance();
                yield return new WaitForSeconds(_delayBetweenChecksSeconds);
            }
        }

        private Distance GetCurrentDistance()
        {
            float distance = Vector3.Distance(transform.position, _target.position);
            for (int i = 0; i < _distances.Length; i++)
                if (distance < _distances[i])
                    return (Distance)i;

            return (Distance)_distances.Length;
        }

        private void OnValidate()
        {
            if (_distances.Length > 3)
                throw new ArgumentException("No support for 4 and more distances!");
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