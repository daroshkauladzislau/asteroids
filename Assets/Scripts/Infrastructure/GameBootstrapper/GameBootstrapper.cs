using Infrastructure.DI;
using UnityEngine;

namespace Infrastructure.GameBootstrapper
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        
        private void Awake()
        {
            _game = new Game(this, SimpleDI.Container);

            DontDestroyOnLoad(this);
        }
    }
}