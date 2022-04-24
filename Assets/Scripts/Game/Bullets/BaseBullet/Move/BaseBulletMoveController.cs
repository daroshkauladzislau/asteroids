using Services.ScreenLimits;
using UnityEngine;

namespace Game.Bullets.BaseBullet.Move
{
    public class BaseBulletMoveController
    {
        protected readonly BaseBulletMoveModel BaseBulletMoveModel;
        protected readonly BaseBulletMove BaseBulletMove;
        protected readonly IScreenLimits ScreenLimits;

        public BaseBulletMoveController(BaseBulletMoveModel baseBulletMoveModel, BaseBulletMove baseBulletMove, IScreenLimits screenLimits)
        {
            BaseBulletMoveModel = baseBulletMoveModel;
            BaseBulletMove = baseBulletMove;
            ScreenLimits = screenLimits;
        }
        
        protected void MoveBullet(GameObject bullet)
        {
            Vector3 distance = bullet.transform.up * BaseBulletMoveModel.Speed * Time.deltaTime;
            BaseBulletMoveModel.Position = bullet.transform.position + distance;

            if (ScreenLimits.OutOfLimits(BaseBulletMoveModel.Position))
            {
                bullet.SetActive(false);
            }

            bullet.transform.position = BaseBulletMoveModel.Position;
        }
    }
}