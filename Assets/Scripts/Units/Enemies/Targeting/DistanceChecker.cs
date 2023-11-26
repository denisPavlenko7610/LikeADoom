using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace LikeADoom.Units.Enemies.Targeting
{
    public class DistanceChecker : MonoBehaviour
    {
        [SerializeField] float[] _distances;
        [SerializeField] float _delayBetweenChecksSeconds;

        static readonly Color[] _distanceColors = { Color.red, Color.yellow, Color.green, Color.cyan };

        Transform _target;
        DistanceTypes _current = DistanceTypes.OutOfRange;
        bool _canCheck = true;
        CancellationTokenSource _ctx;
        
        void OnValidate()
        {
            if (_distances.Length > 3)
                throw new ArgumentException("No supported for 4 and more distances!");
        }

        public void SetTarget(Transform target) => _target = target;
        public DistanceTypes GetDistance() => _current;

        public void StartChecking()
        {
            _ctx = new CancellationTokenSource();
            Check().Forget();
        }

        async UniTaskVoid Check()
        {
            while (_canCheck)
            {
                _current = GetCurrentDistance();
                await UniTask.Delay(TimeSpan.FromSeconds(_delayBetweenChecksSeconds), cancellationToken: _ctx.Token)
                    .SuppressCancellationThrow();
            }
        }

        DistanceTypes GetCurrentDistance()
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
        void OnDrawGizmos()
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