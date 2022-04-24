using Game.Aliens.Collide;
using Game.Bullets.BaseBullet.Collide;
using Game.Meteors.BaseMeteor.MeteorCollide;
using UnityEngine;

namespace Game.Bullets.StandardBullet.Collide
{
    public class StandardBulletCollideController : BaseBulletCollideController
    {
        public StandardBulletCollideController(BaseBulletCollide baseBulletCollide) : base(baseBulletCollide)
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
                BaseBulletCollide.gameObject.SetActive(false);
                meteorCollide.gameObject.SetActive(false);
            }
            
            if (obj.gameObject.TryGetComponent(out AlienCollide alienCollide))
            {
                BaseBulletCollide.gameObject.SetActive(false);
                alienCollide.gameObject.SetActive(false);
            }
        }
    }
}