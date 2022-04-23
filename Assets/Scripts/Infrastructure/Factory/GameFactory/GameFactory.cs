using Game.Bullets;
using Game.Bullets.Bullet;
using Game.Player.PlayerMove;
using Game.Player.PlayerRotate;
using Game.Player.PlayerShoot;
using GameConfig;
using Infrastructure.AssetProvider;
using Services.InputService;
using Services.ScreenLimits;
using UnityEngine;

namespace Infrastructure.Factory.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInputService _inputService;
        private readonly IScreenLimits _screenLimits;

        public GameFactory(IAssetProvider assetProvider, IInputService inputService, IScreenLimits screenLimits)
        {
            _assetProvider = assetProvider;
            _inputService = inputService;
            _screenLimits = screenLimits;
        }
        
        public GameObject CreatePlayerShip()
        {
            PlayerConfig playerConfig = _assetProvider.PlayerConfig();
            
            GameObject playerShip = Object.Instantiate(_assetProvider.PlayerShipObject());
            
            ConfigurePlayerMove(playerConfig, playerShip);
            ConfigurePlayerRotate(playerShip, playerConfig);
            ConfigurePlayerShoot(playerShip, playerConfig);

            return playerShip;
        }

        public GameObject CreateStandardBullet(Vector3 position, Quaternion rotation)
        {
            BaseGunModel bulletModel = new BulletModel(1.0f, 0.0f);
            GameObject bulletPrefab = Object.Instantiate(_assetProvider.BulletObject(), position, rotation);
            BaseGun bulletComponent = bulletPrefab.GetComponent<Bullet>();
            BulletController bulletController =
                new BulletController(bulletModel, bulletComponent, _screenLimits);
            return bulletPrefab;
        }

        private void ConfigurePlayerShoot(GameObject playerShip, PlayerConfig playerConfig)
        {
            PlayerShootModel playerShootModel = new PlayerShootModel(0.0f, 0.0f);
            PlayerShoot playerShootComponent = playerShip.GetComponent<PlayerShoot>();
            PlayerShootController playerShootController =
                new PlayerShootController(playerShootModel, playerShootComponent, _inputService, this);
        }

        private void ConfigurePlayerRotate(GameObject playerShip, PlayerConfig playerConfig)
        {
            PlayerRotate playerShipRotateComponent = playerShip.GetComponent<PlayerRotate>();
            PlayerRotateModel playerRotateModel = new PlayerRotateModel(playerConfig.RotationSpeed);
            PlayerRotateController playerRotateController =
                new PlayerRotateController(playerRotateModel, playerShipRotateComponent, _inputService);
        }

        private void ConfigurePlayerMove(PlayerConfig playerConfig, GameObject playerShip)
        {
            PlayerMoveModel playerShipMoveModel = new PlayerMoveModel(playerConfig.MaxSpeed,
                playerConfig.AccelerationCurve);
            PlayerMove playerShipMoveComponent = playerShip.GetComponent<PlayerMove>();
            PlayerMoveController playerMoveController =
                new PlayerMoveController(playerShipMoveModel, playerShipMoveComponent, _inputService, _screenLimits);
        }
    }
}