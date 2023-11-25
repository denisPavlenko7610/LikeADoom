namespace LikeADoom.ObjectCreation
{
    public interface IObjectFactory<out T>
    {
        public T Create();
    }
}