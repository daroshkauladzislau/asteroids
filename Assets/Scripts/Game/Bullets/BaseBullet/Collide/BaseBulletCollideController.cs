using Game.Aliens.Collide;
using Game.Meteors.BaseMeteor.MeteorCollide;
using Infrastructure.Factory.GameFactory;
using UnityEngine;

namespace Game.Bullets.BaseBullet.Collide
{
    public abstract class BaseBulletCollideController
    {
        protected readonly BaseBulletCollide BaseBulletCollide;
        private readonly IGameFactory _gameFactory;

        protected BaseBulletCollideController(BaseBulletCollide baseBulletCollide, IGameFactory gameFactory)
        {
            BaseBulletCollide = baseBulletCollide;
            _gameFactory = gameFactory;
        }

        protected virtual void OnCollide(Collider2D obj)
        {
            if (obj.gameObject.TryGetComponent(out MeteorCollide meteorCollide))
            {
                meteorCollide.gameObject.SetActive(false);
                AddPoints();
            }
            
            if (obj.gameObject.TryGetComponent(out AlienCollide alienCollide))
            {
                alienCollide.gameObject.SetActive(false);
                AddPoints();
            }
        }

        protected void AddPoints() => 
            _gameFactory.GameScore.CurrentScore++;
    }
}