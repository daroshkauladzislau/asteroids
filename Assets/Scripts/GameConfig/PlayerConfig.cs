using UnityEngine;

namespace GameConfig
{
    [CreateAssetMenu(fileName = "Default Player Config", menuName = "Game Config/Player")]
    public class PlayerConfig : ScriptableObject
    {
        public float MaxSpeed;
        public float RotationSpeed;
        
        public AnimationCurve AccelerationCurve;

        public float LaserDelay;
        public float StandardBulletDelay;
    }
}