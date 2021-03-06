using Game.Bullets.BaseBullet.Collide;
using Game.Meteors.BaseMeteor.MeteorCollide;
using Infrastructure.ConfigProvider;
using Infrastructure.Factory.GameFactory;
using UnityEngine;

namespace Game.Meteors.BigMeteor.Collide
{
    public class BigMeteorCollideController : MeteorCollideController
    {
        private readonly IGameFactory _gameFactory;
        private readonly IConfigProvider _configProvider;

        public BigMeteorCollideController(MeteorCollide meteorCollide, IGameFactory gameFactory, IConfigProvider configProvider) : base(meteorCollide)
        {
            _gameFactory = gameFactory;
            _configProvider = configProvider;

            Subscribe();
        }

        private void Subscribe()
        {
            MeteorCollide.OnCollision += OnMeteorCollision;
        }

        private void OnMeteorCollision(Collider2D obj)
        {
            if (obj.gameObject.TryGetComponent(out BaseBulletCollide bullet))
            {
                CreateMiniMeteors();
            }
        }

        private void CreateMiniMeteors()
        {
            for (int i = 0; i < _configProvider.MeteorConfig().MeteorsAfterDestroy; i++)
            {
                _gameFactory.CreateSmallMeteor(MeteorCollide.gameObject.transform.position);
            }
        }
    }
}