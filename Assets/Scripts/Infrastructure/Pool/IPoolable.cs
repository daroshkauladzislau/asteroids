namespace Infrastructure.Pool
{
    public interface IPoolable
    {
        void OnSpawn();
        void OnDespawn();
    }
}