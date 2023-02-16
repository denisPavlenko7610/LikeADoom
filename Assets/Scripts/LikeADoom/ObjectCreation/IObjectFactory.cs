namespace LikeADoom.Shooting
{
    public interface IObjectFactory<out T>
    {
        public T Create();
    }
}