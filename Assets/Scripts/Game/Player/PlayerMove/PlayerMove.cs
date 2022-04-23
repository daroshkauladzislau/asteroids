using System;
using Services.InputService;
using UnityEngine;

namespace Game.Player.PlayerMove
{
    public class PlayerMove : MonoBehaviour
    {
        public event Action<GameObject> MoveShip;

        private IInputService _input;
        
        private void Update()
        {
            MoveShip?.Invoke(gameObject);
        }
    }
}