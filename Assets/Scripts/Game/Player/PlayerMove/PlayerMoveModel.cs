using UnityEngine;

namespace Game.Player.PlayerMove
{
    public class PlayerMoveModel
    {
        public float MaxSpeed { get; }
        public float SpeedCurveTime { get; set; }
        public Vector3 CurrentPosition { get; set; }
        public AnimationCurve AccelerationCurve { get; }

        public PlayerMoveModel(float maxSpeed, AnimationCurve accelerationCurve)
        {
            MaxSpeed = maxSpeed;
            AccelerationCurve = accelerationCurve;
        }
    }
}