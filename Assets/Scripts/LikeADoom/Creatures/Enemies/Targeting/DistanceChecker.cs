using System;
using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace LikeADoom
{
    public class DistanceChecker : MonoBehaviour
    {
        [SerializeField] private float[] _distances;
        [SerializeField] private float _delayBetweenChecksSeconds;

        private static readonly Color[] _distanceColors = { Color.red, Color.yellow, Color.green, Color.cyan };

        private Transform _target;
        private DistanceTypes _current = DistanceTypes.OutOfRange;
        private bool _canCheck = true;
        private CancellationTokenSource _ctx;
        
        private void OnValidate()
        {
            if (_distances.Length > 3)
                throw new ArgumentException("No supported for 4 and more distances!");
        }

        public void SetTarget(Transform target) => _target = target;
        public DistanceTypes GetDistance() => _current;

        public void StartChecking()
        {
            _ctx = new CancellationTokenSource();
            Check();
        }

        private async UniTaskVoid Check()
        {
            while (_canCheck)
            {
                _current = GetCurrentDistance();
                await UniTask.Delay(TimeSpan.FromSeconds(_delayBetweenChecksSeconds), cancellationToken: _ctx.Token)
                    .SuppressCancellationThrow();
            }
        }

        private DistanceTypes GetCurrentDistance()
        {
            if (_target == null)
            {
                _canCheck = false;
                _ctx.Cancel();
                return default;
            }
            
            float distance = (transform.position - _target.position).sqrMagnitude;
            for (int i = 0; i < _distances.Length; i++)
                if (distance < _distances[i] * _distances[i])
                    return (DistanceTypes)i;

            return (DistanceTypes)_distances.Length;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            for (int i = 0; i < _distances.Length; i++)
            {
                Gizmos.color = _distanceColors[i];
                Gizmos.DrawWireSphere(transform.position, _distances[i]);
            }
        }
#endif
    }
}