using Infrastructure.DI;

namespace Game.MeteorSpawner
{
    public interface IMeteorSpawner : IService
    {
        void StartSpawnMeteors();
        void StopSpawnMeteor();
    }
}