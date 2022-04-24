using System.Collections;
using Infrastructure;
using Infrastructure.ConfigProvider;
using Infrastructure.Factory.GameFactory;
using Services.ScreenLimits;
using UnityEngine;

namespace Game.MeteorSpawner
{
    public class MeteorSpawner : IMeteorSpawner
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IGameFactory _gameFactory;
        private readonly IScreenLimits _screenLimits;
        private readonly IConfigProvider _configProvider;

        public MeteorSpawner(ICoroutineRunner coroutineRunner, IGameFactory gameFactory, IScreenLimits screenLimits, IConfigProvider configProvider)
        {
            _coroutineRunner = coroutineRunner;
            _gameFactory = gameFactory;
            _screenLimits = screenLimits;
            _configProvider = configProvider;
        }

        public void StartSpawnMeteors()
        {
            _coroutineRunner.StartCoroutine(SpawnMeteorCoroutine());
        }

        public void StopSpawnMeteor()
        {
            _coroutineRunner.StopCoroutine(SpawnMeteorCoroutine());
        }

        private IEnumerator SpawnMeteorCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_configProvider.MeteorConfig().SpawnDelay);
                float y = Random.Range(_screenLimits.BottomLimit(), _screenLimits.TopLimit());
                float x = Random.Range(_screenLimits.LeftLimit(), _screenLimits.RightLimit());
                Vector3 spawnPosition = new Vector3(x, y);
                _gameFactory.CreateBigMeteor(spawnPosition);
            }
        }
    }
}