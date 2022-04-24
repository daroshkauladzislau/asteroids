using UnityEngine;

namespace Infrastructure.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        private const string BigMeteorPrefabPath = "Prefabs/Game/BigMeteor";
        private const string PlayerShipPrefabPath = "Prefabs/Game/PlayerShip";
        private const string BulletPrefabPath = "Prefabs/Game/StandardBullet";
        private const string SmallMeteorObjectPath = "Prefabs/Game/SmallMeteor";

        public GameObject PlayerShipObject() => 
            Resources.Load<GameObject>(PlayerShipPrefabPath);

        public GameObject BulletObject() => 
            Resources.Load<GameObject>(BulletPrefabPath);

        public GameObject BigMeteorObject() => 
            Resources.Load<GameObject>(BigMeteorPrefabPath);

        public GameObject SmallMeteorObject() => 
            Resources.Load<GameObject>(SmallMeteorObjectPath);
    }
}