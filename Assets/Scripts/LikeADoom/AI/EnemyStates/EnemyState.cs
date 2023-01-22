using UnityEngine;

namespace LikeADoom
{
    public abstract class EnemyState
    {
        protected readonly IEnemyStateSwitcher StateSwitcher;
        protected readonly Transform Transform;
        protected readonly Transform Target;

        protected EnemyState(IEnemyStateSwitcher stateSwitcher ,Transform transform, Transform target)
        {
            StateSwitcher = stateSwitcher;
            Transform = transform;
            Target = target;
        }

        public abstract void Act();
        
        public virtual void Enter() { }
        public virtual void Exit() { }
    }
}