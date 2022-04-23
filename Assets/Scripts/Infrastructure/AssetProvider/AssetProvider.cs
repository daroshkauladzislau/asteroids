using GameConfig;
using UnityEngine;

namespace Infrastructure.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        private const string PlayerShipPrefabPath = "Prefabs/Game/PlayerShip";
        private const string PlayerConfigPath = "Configs/Game/Player/PlayerConfig";
        private const string BulletPrefabPath = "Prefabs/Game/StandardBullet";

        public GameObject PlayerShipObject() => 
            Resources.Load<GameObject>(PlayerShipPrefabPath);

        public PlayerConfig PlayerConfig() => 
            Resources.Load<PlayerConfig>(PlayerConfigPath);

        public GameObject BulletObject() => 
            Resources.Load<GameObject>(BulletPrefabPath);
    }
}