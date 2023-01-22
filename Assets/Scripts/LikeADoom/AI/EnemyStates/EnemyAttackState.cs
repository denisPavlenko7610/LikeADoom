using UnityEngine;

namespace LikeADoom
{
    public class EnemyAttackState : EnemyState
    {
        public EnemyAttackState(IEnemyStateSwitcher switcher, Transform transform, Transform target) 
            : base(switcher, transform, target)
        {
        }

        public override void Act()
        {
            Debug.Log("Attack!");
        }
    }
}