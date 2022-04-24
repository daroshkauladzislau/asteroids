using UnityEngine;

namespace Infrastructure.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        private const string LaserPrefabPath = "Prefabs/Game/Laser";
        private const string BigMeteorPrefabPath = "Prefabs/Game/BigMeteor";
        private const string PlayerShipPrefabPath = "Prefabs/Game/PlayerShip";
        private const string BulletPrefabPath = "Prefabs/Game/StandardBullet";
        private const string SmallMeteorObjectPath = "Prefabs/Game/SmallMeteor";
        private const string AlienPrefabPath = "Prefabs/Game/Alien";
        private const string HUDPrefabPath = "Prefabs/Game/HUD";
        private const string EndSessionHUDPrefabPath = "Prefabs/Game/EndSessionHUD";

        public GameObject PlayerShipObject() => 
            Resources.Load<GameObject>(PlayerShipPrefabPath);

        public GameObject BulletObject() => 
            Resources.Load<GameObject>(BulletPrefabPath);

        public GameObject BigMeteorObject() => 
            Resources.Load<GameObject>(BigMeteorPrefabPath);

        public GameObject SmallMeteorObject() => 
            Resources.Load<GameObject>(SmallMeteorObjectPath);

        public GameObject LaserObject() => 
            Resources.Load<GameObject>(LaserPrefabPath);

        public GameObject AlienObject() => 
            Resources.Load<GameObject>(AlienPrefabPath);

        public GameObject HUDObject() => 
            Resources.Load<GameObject>(HUDPrefabPath);

        public GameObject EndSessionHUD() => 
            Resources.Load<GameObject>(EndSessionHUDPrefabPath);
    }
}