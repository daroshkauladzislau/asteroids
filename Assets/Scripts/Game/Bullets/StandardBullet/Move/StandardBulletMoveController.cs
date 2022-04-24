using Game.Bullets.BaseBullet.Move;
using Services.ScreenLimits;

namespace Game.Bullets.StandardBullet.Move
{
    public class StandardBulletMoveController : BaseBulletMoveController
    {
        public StandardBulletMoveController(BaseBulletMoveModel baseBulletMoveModel, BaseBulletMove baseBulletMove, IScreenLimits screenLimits) : base(baseBulletMoveModel, baseBulletMove, screenLimits)
        {
            Subscribe();
        }

        private void Subscribe()
        {
            BaseBulletMove.Move += MoveBullet;
        }
    }
}