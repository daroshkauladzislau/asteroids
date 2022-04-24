using Game.Aliens.Move;
using Game.Bullets.BaseBullet.Collide;
using Game.Bullets.BaseBullet.Move;
using Game.Bullets.Laser.Collide;
using Game.Bullets.Laser.Move;
using Game.Bullets.StandardBullet.Collide;
using Game.Bullets.StandardBullet.Move;
using Game.GameScore;
using Game.HUD.EndSessionHUD;
using Game.HUD.GameHUD;
using Game.Meteors.BaseMeteor.MeteorCollide;
using Game.Meteors.BaseMeteor.MeteorMove;
using Game.Meteors.BigMeteor.Collide;
using Game.Meteors.BigMeteor.Move;
using Game.Meteors.SmallMeteor.Collide;
using Game.Meteors.SmallMeteor.Move;
using Game.Player.PlayerCollide;
using Game.Player.PlayerMove;
using Game.Player.PlayerRotate;
using Game.Player.PlayerShoot;
using GameConfig;
using Infrastructure.AssetProvider;
using Infrastructure.ConfigProvider;
using Infrastructure.Services.InputService;
using Infrastructure.Services.ScreenLimits;
using Infrastructure.StateMachine.GameStateMachine;
using UnityEngine;

namespace Infrastructure.Factory.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IConfigProvider _configProvider;
        private readonly IInputService _inputService;
        private readonly IScreenLimits _screenLimits;
        private readonly IGameStateMachine _gameStateMachine;

        public GameFactory(IAssetProvider assetProvider, IConfigProvider configProvider, IInputService inputService, IScreenLimits screenLimits, IGameStateMachine gameStateMachine)
        {
            _assetProvider = assetProvider;
            _configProvider = configProvider;
            _inputService = inputService;
            _screenLimits = screenLimits;
            _gameStateMachine = gameStateMachine;
        }

        public GameObject PlayerShip { get; private set; }
        public PlayerMoveModel PlayerMoveModel { get; private set;}
        public PlayerRotateModel PlayerRotateModel { get; private set;}
        public PlayerShootModel PlayerShootModel { get; private set;}
        public GameScore GameScore { get; private set; }

        public GameObject CreatePlayerShip()
        {
            PlayerConfig playerConfig = _configProvider.PlayerConfig();
            
            GameObject playerShip = Object.Instantiate(_assetProvider.PlayerShipObject());
            
            ConfigurePlayer(playerConfig, playerShip);
            PlayerShip = playerShip;
            return playerShip;
        }

        public GameObject CreateStandardBullet(Vector3 position, Quaternion rotation)
        {
            GunConfig gunConfig = _configProvider.StandardBulletConfig();
            
            GameObject bulletPrefab = Object.Instantiate(_assetProvider.BulletObject(), position, rotation);

            ConfigureStandardBullet(gunConfig, bulletPrefab);

            return bulletPrefab;
        }

        public GameObject CreateLaserBullet(Vector3 position, Quaternion rotation)
        {
            GunConfig gunConfig = _configProvider.LaserBulletConfig();
            
            GameObject bulletPrefab = Object.Instantiate(_assetProvider.LaserObject(), position, rotation);

            ConfigureLaser(gunConfig, bulletPrefab);

            return bulletPrefab;
        }

        public GameObject CreateBigMeteor(Vector3 spawnPosition)
        {
            MeteorConfig meteorConfig = _configProvider.MeteorConfig();
            GameObject meteorObject =
                Object.Instantiate(_assetProvider.BigMeteorObject(), spawnPosition, Quaternion.identity);
            ConfigureBigMeteor(meteorConfig, meteorObject);
            return meteorObject;
        }

        public GameObject CreateSmallMeteor(Vector3 spawnPosition)
        {
            MeteorConfig meteorConfig = _configProvider.MeteorConfig();
            GameObject meteorObject =
                Object.Instantiate(_assetProvider.SmallMeteorObject(), spawnPosition, Quaternion.identity);
            ConfigureSmallMeteor(meteorConfig, meteorObject);
            return meteorObject;
        }

        public GameObject CreateAlien(Vector3 position)
        {
            AlienConfig alienConfig = _configProvider.AlienConfig();
            GameObject alienObject = Object.Instantiate(_assetProvider.AlienObject(), position, Quaternion.identity);
            ConfigureAlienMove(alienConfig, alienObject);
            return alienObject;
        }

        public GameObject CreateHUD()
        {
            GameObject HUDObject = Object.Instantiate(_assetProvider.HUDObject());
            ConfigureHUD(HUDObject);
            return HUDObject;
        }

        public GameObject CreateEndSessionHUD()
        {
            GameObject endSessionHUDObject = Object.Instantiate(_assetProvider.EndSessionHUD());
            ConfigureEndSessionHUD(endSessionHUDObject);
            return endSessionHUDObject;
        }

        public void CreateGameScore()
        {
            GameScore gameScore = new GameScore();
            GameScore = gameScore;
        }

        private void ConfigurePlayer(PlayerConfig playerConfig, GameObject playerShip)
        {
            ConfigurePlayerMove(playerConfig, playerShip);
            ConfigurePlayerRotate(playerShip, playerConfig);
            ConfigurePlayerShoot(playerShip, playerConfig);
            ConfigurePlayerCollide(playerShip);
        }

        private void ConfigureStandardBullet(GunConfig gunConfig, GameObject bulletPrefab)
        {
            ConfigureStandardBulletMove(gunConfig, bulletPrefab);
            ConfigureStandardBulletCollide(bulletPrefab);
        }

        private void ConfigureLaser(GunConfig gunConfig, GameObject bulletPrefab)
        {
            ConfigureLaserMove(gunConfig, bulletPrefab);
            ConfigureLaserCollide(bulletPrefab);
        }

        private void ConfigureBigMeteor(MeteorConfig meteorConfig, GameObject meteorObject)
        {
            ConfigureBigMeteorMove(meteorConfig, meteorObject);
            ConfigureBigMeteorCollide(meteorObject);
        }

        private void ConfigureSmallMeteor(MeteorConfig meteorConfig, GameObject meteorObject)
        {
            ConfigureSmallMeteorMove(meteorConfig, meteorObject);
            ConfigureSmallMeteorCollide(meteorObject);
        }

        private void ConfigureEndSessionHUD(GameObject endSessionHUDObject)
        {
            EndSessionHUD endSessionHUD = endSessionHUDObject.GetComponent<EndSessionHUD>();
            EndSessionHUDController endSessionHUDController =
                new EndSessionHUDController(endSessionHUD, this, _gameStateMachine);
        }

        private void ConfigurePlayerShoot(GameObject playerShip, PlayerConfig playerConfig)
        {
            PlayerShootModel playerShootModel = new PlayerShootModel();
            PlayerShoot playerShootComponent = playerShip.GetComponent<PlayerShoot>();
            PlayerShootController playerShootController =
                new PlayerShootController(playerShootModel, playerShootComponent, _inputService, this,
                    playerConfig.LaserDelay, playerConfig.StandardBulletDelay);
            PlayerShootModel = playerShootModel;
        }

        private void ConfigurePlayerRotate(GameObject playerShip, PlayerConfig playerConfig)
        {
            PlayerRotate playerShipRotateComponent = playerShip.GetComponent<PlayerRotate>();
            PlayerRotateModel playerRotateModel = new PlayerRotateModel(playerConfig.RotationSpeed);
            PlayerRotateController playerRotateController =
                new PlayerRotateController(playerRotateModel, playerShipRotateComponent, _inputService);
            PlayerRotateModel = playerRotateModel;
        }

        private void ConfigurePlayerMove(PlayerConfig playerConfig, GameObject playerShip)
        {
            PlayerMoveModel playerShipMoveModel = new PlayerMoveModel(playerConfig.MaxSpeed,
                playerConfig.AccelerationCurve);
            PlayerMove playerShipMoveComponent = playerShip.GetComponent<PlayerMove>();
            PlayerMoveController playerMoveController =
                new PlayerMoveController(playerShipMoveModel, playerShipMoveComponent, _inputService, _screenLimits);
            PlayerMoveModel = playerShipMoveModel;
        }

        private void ConfigurePlayerCollide(GameObject playerShip)
        {
            PlayerCollide playerCollide = playerShip.GetComponent<PlayerCollide>();
            PlayerCollideController playerCollideController =
                new PlayerCollideController(playerCollide, _gameStateMachine);
        }

        private void ConfigureHUD(GameObject HUDObject)
        {
            HUD hud = HUDObject.GetComponent<HUD>();

            HUDController hudController = new HUDController(hud, this);
        }

        private void ConfigureAlienMove(AlienConfig alienConfig, GameObject alienObject)
        {
            AlienMoveModel alienMoveModel = new AlienMoveModel(alienConfig.Speed);
            AlienMove alienMove = alienObject.GetComponent<AlienMove>();
            AlienMoveController alienMoveController = new AlienMoveController(alienMoveModel, alienMove, this);
        }

        private void ConfigureStandardBulletCollide(GameObject bulletPrefab)
        {
            BaseBulletCollide baseBulletCollide = bulletPrefab.GetComponent<BaseBulletCollide>();
            BaseBulletCollideController baseBulletCollideController =
                new StandardBulletCollideController(baseBulletCollide, this);
        }

        private void ConfigureStandardBulletMove(GunConfig gunConfig, GameObject bulletPrefab)
        {
            BaseBulletMoveModel bulletModel = new StandardBulletMoveModel(gunConfig.Speed);
            BaseBulletMove bulletComponent = bulletPrefab.GetComponent<BaseBulletMove>();
            BaseBulletMoveController standardBulletMoveController =
                new StandardBulletMoveController(bulletModel, bulletComponent, _screenLimits);
        }

        private void ConfigureLaserCollide(GameObject bulletPrefab)
        {
            BaseBulletCollide baseBulletCollide = bulletPrefab.GetComponent<BaseBulletCollide>();
            BaseBulletCollideController baseBulletCollideController =
                new LaserCollideController(baseBulletCollide, this);
        }

        private void ConfigureLaserMove(GunConfig gunConfig, GameObject bulletPrefab)
        {
            BaseBulletMoveModel bulletModel = new LaserMoveModel(gunConfig.Speed);
            BaseBulletMove bulletComponent = bulletPrefab.GetComponent<BaseBulletMove>();
            BaseBulletMoveController laserMoveController =
                new StandardBulletMoveController(bulletModel, bulletComponent, _screenLimits);
        }

        private void ConfigureBigMeteorCollide(GameObject meteorObject)
        {
            MeteorCollide meteorCollide = meteorObject.GetComponent<MeteorCollide>();
            MeteorCollideController meteorCollideController =
                new BigMeteorCollideController(meteorCollide, this, _configProvider);
        }

        private void ConfigureBigMeteorMove(MeteorConfig meteorConfig, GameObject meteorObject)
        {
            MeteorMoveModel meteorMoveModel = new BigMeteorMoveModelModel(meteorConfig.BigMeteorSpeed, CalculateRandomDirection());
            MeteorMove meteorMove = meteorObject.GetComponent<MeteorMove>();
            MeteorController meteorController = new BigMeteorController(meteorMoveModel, meteorMove, _screenLimits);
        }

        private void ConfigureSmallMeteorCollide(GameObject meteorObject)
        {
            MeteorCollide meteorCollide = meteorObject.GetComponent<MeteorCollide>();
            MeteorCollideController meteorCollideController = new SmallMeteorCollideController(meteorCollide);
        }

        private void ConfigureSmallMeteorMove(MeteorConfig meteorConfig, GameObject meteorObject)
        {
            MeteorMoveModel meteorMoveModel =
                new SmallMeteorMoveModelModel(meteorConfig.SmallMeteorSpeed, CalculateRandomDirection());
            MeteorMove meteorMove = meteorObject.GetComponent<MeteorMove>();
            MeteorController meteorController = new SmallMeteorController(meteorMoveModel, meteorMove, _screenLimits);
        }

        private Vector2 CalculateRandomDirection() => 
            new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
    }
}