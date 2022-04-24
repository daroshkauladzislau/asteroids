using Infrastructure.Factory.GameFactory;
using Services.InputService;
using UnityEngine;

namespace Game.Player.PlayerShoot
{
    public class PlayerShootController
    {
        private readonly PlayerShootModel _playerShootModel;
        private readonly PlayerShoot _playerShoot;
        private readonly IInputService _inputService;
        private readonly IGameFactory _gameFactory;
        private readonly float _laserDelay;
        private readonly float _standardDelay;

        public PlayerShootController(PlayerShootModel playerShootModel, PlayerShoot playerShoot, IInputService inputService, IGameFactory gameFactory, float laserDelay, float standardDelay)
        {
            _playerShootModel = playerShootModel;
            _playerShoot = playerShoot;
            _inputService = inputService;
            _gameFactory = gameFactory;
            _laserDelay = laserDelay;
            _standardDelay = standardDelay;

            Subscribe();
        }

        private void Subscribe()
        {
            _playerShoot.Shoot += Shoot;
        }

        private void Shoot(GameObject obj)
        {
            CalculateDelay();

            if (IsReadyToShootStandard())
            {
                StandardBulletShoot(obj);
            }

            if (IsReadyToShootLaser())
            {
                LaserShoot(obj);
            }
        }

        private bool IsReadyToShootLaser() => 
            _inputService.Player.FireLaser.triggered && _playerShootModel.LaserShootDelay <= 0.0f;

        private bool IsReadyToShootStandard() => 
            _inputService.Player.FireStandard.triggered && _playerShootModel.StandardBulletShootDelay <= 0.0f;

        private void LaserShoot(GameObject obj)
        {
            _gameFactory.CreateLaserBullet(obj.transform.position, obj.transform.rotation);
            _playerShootModel.LaserShootDelay = _laserDelay;
        }

        private void StandardBulletShoot(GameObject obj)
        {
            _gameFactory.CreateStandardBullet(obj.transform.position, obj.transform.rotation);
            _playerShootModel.StandardBulletShootDelay = _standardDelay;
        }

        private void CalculateDelay()
        {
            _playerShootModel.LaserShootDelay -= Time.deltaTime;
            _playerShootModel.StandardBulletShootDelay -= Time.deltaTime;
        }
    }
}