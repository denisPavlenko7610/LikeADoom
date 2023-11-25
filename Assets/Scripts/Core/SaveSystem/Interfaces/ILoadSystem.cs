namespace LikeADoom.Core.SaveSystem.Interfaces
{
    public interface ILoadSystem
    {
        void Load<T>() where T : ISavableData;
    }
}