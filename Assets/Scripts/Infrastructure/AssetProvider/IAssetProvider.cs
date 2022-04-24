using GameConfig;
using Infrastructure.DI;
using UnityEngine;

namespace Infrastructure.AssetProvider
{
    public interface IAssetProvider : IService
    {
        GameObject PlayerShipObject();
        GameObject BulletObject();
        GameObject BigMeteorObject();
        GameObject SmallMeteorObject();
        GameObject LaserObject();
    }
}