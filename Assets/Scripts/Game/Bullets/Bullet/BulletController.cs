using Services.ScreenLimits;
using UnityEngine;

namespace Game.Bullets.Bullet
{
    public class BulletController
    {
        private readonly BaseGunModel _baseGunModel;
        private readonly BaseGun _baseGun;
        private readonly IScreenLimits _screenLimits;

        public BulletController(BaseGunModel baseGunModel, BaseGun baseGun, IScreenLimits screenLimits)
        {
            _baseGunModel = baseGunModel;
            _baseGun = baseGun;
            _screenLimits = screenLimits;

            Subscribe();
        }

        private void Subscribe()
        {
            _baseGun.Move += MoveBullet;
            _baseGun.OnCollide += OnBulletCollide;
        }

        private void UnSubscribe()
        {
            _baseGun.Move -= MoveBullet;
            _baseGun.OnCollide -= OnBulletCollide;
        }

        private void MoveBullet(GameObject bullet)
        {
            Vector3 distance = bullet.transform.up * _baseGunModel.Speed * Time.deltaTime;
            _baseGunModel.Position = bullet.transform.position + distance;

            if (_screenLimits.OutOfLimits(_baseGunModel.Position))
            {
                UnSubscribe();
                bullet.SetActive(false);
            }

            bullet.transform.position = _baseGunModel.Position;
        }

        private void OnBulletCollide(Collision2D obj)
        {
            
        }
    }
}