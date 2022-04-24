using Infrastructure.Factory.GameFactory;
using Infrastructure.Services.InputService;
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
            _inputService.Player.FireLaser.triggered  && _playerShootModel.LaserShootCount > 0;

        private bool IsReadyToShootStandard() => 
            _inputService.Player.FireStandard.triggered && _playerShootModel.StandardBulletShootDelay <= 0.0f;

        private void LaserShoot(GameObject obj)
        {
            _gameFactory.CreateLaserBullet(obj.transform.position, obj.transform.rotation);
            _playerShootModel.LaserShootCount--;
        }

        private void StandardBulletShoot(GameObject obj)
        {
            _gameFactory.CreateStandardBullet(obj.transform.position, obj.transform.rotation);
            _playerShootModel.StandardBulletShootDelay = _standardDelay;
        }

        private void CalculateDelay()
        {
            CalculateLaserDelay();
            CalculateStandardBulletDelay();
        }

        private void CalculateStandardBulletDelay()
        {
            if (_playerShootModel.StandardBulletShootDelay >= 0)
            {
                _playerShootModel.StandardBulletShootDelay -= Time.deltaTime;
            }
        }

        private void CalculateLaserDelay()
        {
            if (_playerShootModel.LaserShootDelay >= 0)
            {
                _playerShootModel.LaserShootDelay -= Time.deltaTime;
            }
            else
            {
                _playerShootModel.LaserShootCount++;
                _playerShootModel.LaserShootDelay = _laserDelay;
            }
        }
    }
}