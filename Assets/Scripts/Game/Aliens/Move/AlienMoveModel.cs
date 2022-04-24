using UnityEngine;

namespace Game.Aliens.Move
{
    public class AlienMoveModel
    {
        public float Speed;
        public Vector3 Position;
        
        public AlienMoveModel(float speed)
        {
            Speed = speed;
        }
    }
}