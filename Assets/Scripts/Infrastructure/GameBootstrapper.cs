using System.Collections;
using Infrastructure.DI;
using UnityEngine;

namespace Infrastructure
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