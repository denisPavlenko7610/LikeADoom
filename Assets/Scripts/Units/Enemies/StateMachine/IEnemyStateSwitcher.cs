namespace LikeADoom.Units.Enemies.StateMachine
{
    public interface IEnemyStateSwitcher
    {
        public void SwitchTo(EnemyStates.EnemyStates state);
    }
}