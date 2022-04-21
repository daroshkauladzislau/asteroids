using UnityEngine;

namespace GameConfig
{
    [CreateAssetMenu(fileName = "Default Player Config", menuName = "Game Config/Player")]
    public class PlayerConfig : ScriptableObject
    {
        public float MaxSpeed;
        public AnimationCurve AccelerationCurve;
    }
}