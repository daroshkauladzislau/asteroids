using Game.Player.PlayerMove;
using Game.Player.PlayerRotate;
using Game.Player.PlayerShoot;
using Infrastructure.DI;
using UnityEngine;

namespace Infrastructure.Factory.GameFactory
{
    public interface IGameFactory : IService
    {
        GameObject PlayerShip { get; }
        PlayerMoveModel PlayerMoveModel { get; }
        PlayerRotateModel PlayerRotateModel { get; }
        PlayerShootModel PlayerShootModel { get; }
        GameObject CreatePlayerShip();
        GameObject CreateStandardBullet(Vector3 position, Quaternion rotation);
        GameObject CreateLaserBullet(Vector3 transformPosition, Quaternion rotation);
        GameObject CreateBigMeteor(Vector3 spawnPosition);
        GameObject CreateSmallMeteor(Vector3 spawnPosition);
        GameObject CreateAlien(Vector3 position);
        GameObject CreateHUD();
        GameObject CreateEndSessionHUD();
    }
}