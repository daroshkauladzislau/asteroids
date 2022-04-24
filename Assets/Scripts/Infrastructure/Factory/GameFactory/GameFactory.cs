using Game.Bullets;
using Game.Bullets.BaseBullet.Collide;
using Game.Bullets.BaseBullet.Move;
using Game.Bullets.Laser.Collide;
using Game.Bullets.Laser.Move;
using Game.Bullets.StandardBullet.Collide;
using Game.Bullets.StandardBullet.Move;
using Game.Meteors.BaseMeteor.MeteorCollide;
using Game.Meteors.BaseMeteor.MeteorMove;
using Game.Meteors.BigMeteor.Collide;
using Game.Meteors.BigMeteor.Move;
using Game.Meteors.SmallMeteor.Collide;
using Game.Meteors.SmallMeteor.Move;
using Game.Player.PlayerMove;
using Game.Player.PlayerRotate;
using Game.Player.PlayerShoot;
using GameConfig;
using Infrastructure.AssetProvider;
using Infrastructure.ConfigProvider;
using Services.InputService;
using Services.ScreenLimits;
using UnityEngine;

namespace Infrastructure.Factory.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IConfigProvider _configProvider;
        private readonly IInputService _inputService;
        private readonly IScreenLimits _screenLimits;

        public GameFactory(IAssetProvider assetProvider, IConfigProvider configProvider, IInputService inputService, IScreenLimits screenLimits)
        {
            _assetProvider = assetProvider;
            _configProvider = configProvider;
            _inputService = inputService;
            _screenLimits = screenLimits;
        }
        
        public GameObject CreatePlayerShip()
        {
            PlayerConfig playerConfig = _configProvider.PlayerConfig();
            GameObject playerShip = Object.Instantiate(_assetProvider.PlayerShipObject());
            ConfigurePlayer(playerConfig, playerShip);
            return playerShip;
        }

        public GameObject CreateStandardBullet(Vector3 position, Quaternion rotation)
        {
            GunConfig gunConfig = _configProvider.StandardBulletConfig();
            GameObject bulletPrefab = Object.Instantiate(_assetProvider.BulletObject(), position, rotation);

            BaseBulletMoveModel bulletModel = new StandardBulletMoveModel(gunConfig.Speed);
            BaseBulletMove bulletComponent = bulletPrefab.GetComponent<BaseBulletMove>();
            BaseBulletMoveController standardBulletMoveController =
                new StandardBulletMoveController(bulletModel, bulletComponent, _screenLimits);

            BaseBulletCollide baseBulletCollide = bulletPrefab.GetComponent<BaseBulletCollide>();
            BaseBulletCollideController baseBulletCollideController =
                new StandardBulletCollideController(baseBulletCollide);
            
            return bulletPrefab;
        }

        public GameObject CreateLaserBullet(Vector3 position, Quaternion rotation)
        {
            GunConfig gunConfig = _configProvider.LaserBulletConfig();
            GameObject bulletPrefab = Object.Instantiate(_assetProvider.LaserObject(), position, rotation);

            BaseBulletMoveModel bulletModel = new LaserMoveModel(gunConfig.Speed);
            BaseBulletMove bulletComponent = bulletPrefab.GetComponent<BaseBulletMove>();
            BaseBulletMoveController laserMoveController =
                new StandardBulletMoveController(bulletModel, bulletComponent, _screenLimits);

            BaseBulletCollide baseBulletCollide = bulletPrefab.GetComponent<BaseBulletCollide>();
            BaseBulletCollideController baseBulletCollideController =
                new LaserCollideController(baseBulletCollide);
            
            return bulletPrefab;
        }

        public GameObject CreateBigMeteor(Vector3 spawnPosition)
        {
            MeteorConfig meteorConfig = _configProvider.MeteorConfig();
            
            MeteorMoveModel meteorMoveModel = new BigMeteorMoveModelModel(meteorConfig.BigMeteorSpeed, new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)));
            GameObject meteorObject =
                Object.Instantiate(_assetProvider.BigMeteorObject(), spawnPosition, Quaternion.identity);
            MeteorMove meteorMove = meteorObject.GetComponent<MeteorMove>();
            MeteorController meteorController = new BigMeteorController(meteorMoveModel, meteorMove, _screenLimits);

            MeteorCollide meteorCollide = meteorObject.GetComponent<MeteorCollide>();
            MeteorCollideController meteorCollideController =
                new BigMeteorCollideController(meteorCollide, this, _configProvider);
            
            return meteorObject;
        }

        public GameObject CreateSmallMeteor(Vector3 spawnPosition)
        {
            MeteorConfig meteorConfig = _configProvider.MeteorConfig();

            MeteorMoveModel meteorMoveModel =
                new SmallMeteorMoveModelModel(meteorConfig.SmallMeteorSpeed, new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)));
            GameObject meteorObject =
                Object.Instantiate(_assetProvider.SmallMeteorObject(), spawnPosition, Quaternion.identity);
            MeteorMove meteorMove = meteorObject.GetComponent<MeteorMove>();
            MeteorController meteorController = new SmallMeteorController(meteorMoveModel, meteorMove, _screenLimits);

            MeteorCollide meteorCollide = meteorObject.GetComponent<MeteorCollide>();
            MeteorCollideController meteorCollideController = new SmallMeteorCollideController(meteorCollide);
            
            return meteorObject;
        }

        private void ConfigurePlayerShoot(GameObject playerShip, PlayerConfig playerConfig)
        {
            PlayerShootModel playerShootModel = new PlayerShootModel(0.0f, 0.0f);
            PlayerShoot playerShootComponent = playerShip.GetComponent<PlayerShoot>();
            PlayerShootController playerShootController =
                new PlayerShootController(playerShootModel, playerShootComponent, _inputService, this,
                    playerConfig.LaserDelay, playerConfig.StandardBulletDelay);
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

        private void ConfigurePlayer(PlayerConfig playerConfig, GameObject playerShip)
        {
            ConfigurePlayerMove(playerConfig, playerShip);
            ConfigurePlayerRotate(playerShip, playerConfig);
            ConfigurePlayerShoot(playerShip, playerConfig);
        }
    }
}