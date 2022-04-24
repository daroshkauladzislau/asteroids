using System.Collections;
using Infrastructure;
using Infrastructure.ConfigProvider;
using Infrastructure.Factory.GameFactory;
using Services.ScreenLimits;
using UnityEngine;

namespace Game.AlienSpawner
{
    public class AlienSpawner : IAlienSpawner
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IGameFactory _gameFactory;
        private readonly IScreenLimits _screenLimits;
        private readonly IConfigProvider _configProvider;

        public AlienSpawner(ICoroutineRunner coroutineRunner, IGameFactory gameFactory, IScreenLimits screenLimits, IConfigProvider configProvider)
        {
            _coroutineRunner = coroutineRunner;
            _gameFactory = gameFactory;
            _screenLimits = screenLimits;
            _configProvider = configProvider;
        }

        public void StartSpawnAliens()
        {
            _coroutineRunner.StartCoroutine(SpawnAlienCoroutine());
        }

        public void StopSpawnAliens()
        {
            _coroutineRunner.StopCoroutine(SpawnAlienCoroutine());
        }

        private IEnumerator SpawnAlienCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_configProvider.AlienConfig().SpawnDelay);
                float y = Random.Range(_screenLimits.BottomLimit(), _screenLimits.TopLimit());
                float x = Random.Range(_screenLimits.LeftLimit(), _screenLimits.RightLimit());
                Vector3 spawnPosition = new Vector3(x, y);
                _gameFactory.CreateAlien(spawnPosition);
            }
        }
    }
}