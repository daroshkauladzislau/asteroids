using System;
using UnityEngine;

namespace Game.Aliens.Move
{
    public class AlienMove : MonoBehaviour
    {
        public event Action<GameObject> MoveToPlayer; 

        private void Update()
        {
            MoveToPlayer?.Invoke(gameObject);
        }
    }
}