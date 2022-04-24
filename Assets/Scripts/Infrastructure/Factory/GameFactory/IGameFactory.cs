using Infrastructure.DI;
using UnityEngine;

namespace Infrastructure.Factory.GameFactory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayerShip();
        GameObject CreateStandardBullet(Vector3 position, Quaternion rotation);
        GameObject CreateBigMeteor(Vector3 spawnPosition);
        GameObject CreateSmallMeteor(Vector3 spawnPosition);
    }
}