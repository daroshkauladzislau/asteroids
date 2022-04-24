using Infrastructure.DI;

namespace Game.AlienSpawner
{
    public interface IAlienSpawner : IService
    {
        void StartSpawnAliens();
        void StopSpawnAliens();
    }
}