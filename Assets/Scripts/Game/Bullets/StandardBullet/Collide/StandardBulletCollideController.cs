using Game.Bullets.BaseBullet.Collide;

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
    }
}