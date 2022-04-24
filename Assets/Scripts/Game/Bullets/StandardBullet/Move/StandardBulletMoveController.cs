using Services.ScreenLimits;
using UnityEngine;

namespace Game.Bullets.StandardBullet.Move
{
    public class BulletController
    {
        private readonly BaseBulletMoveModel _baseBulletMoveModel;
        private readonly BaseBulletMove _baseBulletMove;
        private readonly IScreenLimits _screenLimits;

        public BulletController(BaseBulletMoveModel baseBulletMoveModel, BaseBulletMove baseBulletMove, IScreenLimits screenLimits)
        {
            _baseBulletMoveModel = baseBulletMoveModel;
            _baseBulletMove = baseBulletMove;
            _screenLimits = screenLimits;

            Subscribe();
        }

        private void Subscribe()
        {
            _baseBulletMove.Move += MoveBullet;
        }

        private void UnSubscribe()
        {
            _baseBulletMove.Move -= MoveBullet;
        }

        private void MoveBullet(GameObject bullet)
        {
            Vector3 distance = bullet.transform.up * _baseBulletMoveModel.Speed * Time.deltaTime;
            _baseBulletMoveModel.Position = bullet.transform.position + distance;

            if (_screenLimits.OutOfLimits(_baseBulletMoveModel.Position))
            {
                UnSubscribe();
                bullet.SetActive(false);
            }

            bullet.transform.position = _baseBulletMoveModel.Position;
        }
    }
}