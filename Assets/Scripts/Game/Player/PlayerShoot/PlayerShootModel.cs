namespace Game.Player.PlayerShoot
{
    public class PlayerShootModel
    {
        public float StandardBulletShootDelay;
        public float LaserShootDelay;

        public PlayerShootModel(float standardBulletShootDelay, float laserShootDelay)
        {
            StandardBulletShootDelay = standardBulletShootDelay;
            LaserShootDelay = laserShootDelay;
        }
    }
}