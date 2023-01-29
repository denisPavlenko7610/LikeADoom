using UnityEngine;

namespace LikeADoom
{
    public class EnemyIdleState : EnemyState
    {
        public EnemyIdleState(IEnemyStateSwitcher switcher, Transform transform, Transform target) 
            : base(switcher, transform, target)
        {
        }
        
        public override void Act()
        {
        }
    }
}