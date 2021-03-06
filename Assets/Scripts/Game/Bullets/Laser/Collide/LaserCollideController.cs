using Game.Aliens.Collide;
using Game.Bullets.BaseBullet.Collide;
using Game.Meteors.BaseMeteor.MeteorCollide;
using Infrastructure.Factory.GameFactory;
using UnityEngine;

namespace Game.Bullets.Laser.Collide
{
    public class LaserCollideController : BaseBulletCollideController
    {
        public LaserCollideController(BaseBulletCollide baseBulletCollide, IGameFactory gameFactory) : base(baseBulletCollide, gameFactory)
        {
            Subscribe();
        }

        private void Subscribe()
        {
            BaseBulletCollide.OnCollide += OnCollide;
        }

        protected override void OnCollide(Collider2D obj)
        {
            base.OnCollide(obj);
        }
    }
}