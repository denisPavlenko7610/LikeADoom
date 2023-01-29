using UnityEngine;

namespace LikeADoom
{
    public class EnemyChaseState : EnemyState
    {
        private readonly EnemyMovement _movement;

        public EnemyChaseState(IEnemyStateSwitcher switcher, Transform transform, Transform target, EnemyMovement movement) 
            : base(switcher, transform, target)
        {
            _movement = movement;
        }

        public override void Act()
        {
            _movement.MoveTo(Target);
        }
    }
}