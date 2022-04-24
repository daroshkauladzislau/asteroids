using Game.Aliens.Collide;
using Game.Meteors.BaseMeteor.MeteorCollide;
using UnityEngine;

namespace Game.Bullets.BaseBullet.Collide
{
    public abstract class BaseBulletCollideController
    {
        protected readonly BaseBulletCollide BaseBulletCollide;

        protected BaseBulletCollideController(BaseBulletCollide baseBulletCollide)
        {
            BaseBulletCollide = baseBulletCollide;
        }

        protected virtual void OnCollide(Collider2D obj)
        {
            if (obj.gameObject.TryGetComponent(out MeteorCollide meteorCollide))
            {
                meteorCollide.gameObject.SetActive(false);
            }
            
            if (obj.gameObject.TryGetComponent(out AlienCollide alienCollide))
            {
                alienCollide.gameObject.SetActive(false);
            }
        }
    }
}