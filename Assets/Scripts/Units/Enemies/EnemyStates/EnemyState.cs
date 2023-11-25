using LikeADoom.Units.Enemies.StateMachine;
using UnityEngine;

namespace LikeADoom.Units.Enemies.EnemyStates
{
    public abstract class EnemyState
    {
        protected readonly IEnemyStateSwitcher StateSwitcher;
        protected readonly Transform Transform;
        protected readonly Targeting.Targeting Targeting;

        protected EnemyState(IEnemyStateSwitcher stateSwitcher, Transform transform, Targeting.Targeting targeting)
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