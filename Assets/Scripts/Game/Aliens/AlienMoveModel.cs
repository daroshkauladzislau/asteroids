using UnityEngine;

namespace Game.Aliens
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