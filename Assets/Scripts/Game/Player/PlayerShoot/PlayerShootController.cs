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

        public PlayerShootController(PlayerShootModel playerShootModel, PlayerShoot playerShoot, IInputService inputService, IGameFactory gameFactory)
        {
            _playerShootModel = playerShootModel;
            _playerShoot = playerShoot;
            _inputService = inputService;
            _gameFactory = gameFactory;

            Subscribe();
        }

        private void Subscribe()
        {
            _playerShoot.Shoot += Shoot;
        }

        private void Shoot(GameObject obj)
        {
            if (_inputService.Player.Fire.triggered)
            {
                _gameFactory.CreateStandardBullet(obj.transform.position, obj.transform.rotation);
            }
        }
    }
}