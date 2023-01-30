using UnityEngine;

namespace LikeADoom
{
    public abstract class EnemyState
    {
        protected readonly IEnemyStateSwitcher StateSwitcher;
        protected readonly Transform Transform;
        protected readonly Targeting Targeting;

        protected EnemyState(IEnemyStateSwitcher stateSwitcher, Transform transform, Targeting targeting)
        {
            StateSwitcher = stateSwitcher;
            Transform = transform;
            Targeting = targeting;
        }

        public abstract void Act();
        
        public virtual void Enter() { }
        public virtual void Exit() { }
    }
}