using GameConfig;
using Infrastructure.DI;
using UnityEngine;

namespace Infrastructure.AssetProvider
{
    public interface IAssetProvider : IService
    {
        GameObject PlayerShipObject();
        PlayerConfig PlayerConfig();
        GameObject BulletObject();
    }
}