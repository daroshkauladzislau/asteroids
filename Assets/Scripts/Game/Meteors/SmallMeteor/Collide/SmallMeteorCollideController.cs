using Game.Bullets.StandardBullet.Move;
using Game.Meteors.BaseMeteor.MeteorCollide;
using UnityEngine;

namespace Game.Meteors.SmallMeteor.Collide
{
    public class SmallMeteorCollideController : MeteorCollideController
    {
        public SmallMeteorCollideController(MeteorCollide meteorCollide) : base(meteorCollide)
        {
            Subscribe();
        }
        
        private void Subscribe()
        {
            MeteorCollide.OnCollision += OnMeteorCollision;
        }

        private void OnMeteorCollision(Collider2D obj)
        {
            if (obj.gameObject.TryGetComponent(out StandardBulletMove bullet))
            {
                bullet.gameObject.SetActive(false);
                MeteorCollide.gameObject.SetActive(false);
            }
        }
    }
}