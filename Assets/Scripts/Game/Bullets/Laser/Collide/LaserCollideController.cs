using Game.Bullets.BaseBullet.Collide;
using Game.Meteors.BaseMeteor.MeteorCollide;
using UnityEngine;

namespace Game.Bullets.Laser.Collide
{
    public class LaserCollideController : BaseBulletCollideController
    {
        public LaserCollideController(BaseBulletCollide baseBulletCollide) : base(baseBulletCollide)
        {
            Subscribe();
        }

        private void Subscribe()
        {
            BaseBulletCollide.OnCollide += OnCollide;
        }

        protected override void OnCollide(Collider2D obj)
        {
            if (obj.gameObject.TryGetComponent(out MeteorCollide meteorCollide))
            {
                meteorCollide.gameObject.SetActive(false);
            }
        }
    }
}