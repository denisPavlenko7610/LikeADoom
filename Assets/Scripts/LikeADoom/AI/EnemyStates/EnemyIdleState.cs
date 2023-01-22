using UnityEngine;

namespace LikeADoom
{
    public class EnemyIdleState : EnemyState
    {
        private readonly LayerMask _checkMask;
        private readonly float _checkRadius;

        private Collider[] _buffer;

        public EnemyIdleState(IEnemyStateSwitcher switcher, Transform transform, Transform target, float checkRadius, LayerMask checkMask) 
            : base(switcher, transform, target)
        {
            _checkMask = checkMask;
            _checkRadius = checkRadius;
            _buffer = new Collider[5];
        }
        
        public override void Act()
        {
            var size = Physics.OverlapSphereNonAlloc(Transform.position, _checkRadius, _buffer, _checkMask);
            
            Debug.Log($"Size: {size}");
            for (int i = 0; i < size; i++)
                Debug.Log($"Collider: {_buffer[i].name}");

            for (int i = 0; i < size; i++)
            {
                if (_buffer[i].transform == Target)
                {
                    StateSwitcher.SwitchTo(EnemyStates.Chase);
                    Debug.Log("Found a target!");
                }
                
                Debug.Log("Found something, but not a target!");
            }
        }
    }
}