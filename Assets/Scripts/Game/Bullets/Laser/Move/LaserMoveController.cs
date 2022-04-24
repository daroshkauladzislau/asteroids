using Game.Bullets.BaseBullet.Move;
using Infrastructure.Services.ScreenLimits;

namespace Game.Bullets.Laser.Move
{
    public class LaserMoveController : BaseBulletMoveController
    {
        public LaserMoveController(BaseBulletMoveModel baseBulletMoveModel, BaseBulletMove baseBulletMove, IScreenLimits screenLimits) : base(baseBulletMoveModel, baseBulletMove, screenLimits)
        {
            Subscribe();
        }

        private void Subscribe()
        {
            BaseBulletMove.Move += MoveBullet;
        }
    }
}