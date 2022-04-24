using Game.Meteors.BaseMeteor.MeteorMove;
using Infrastructure.Services.ScreenLimits;
using UnityEngine;

namespace Game.Meteors.BigMeteor.Move
{
    public class BigMeteorController : MeteorController
    {
        public BigMeteorController(MeteorMoveModel meteorMoveModel, MeteorMove meteorMove, IScreenLimits screenLimits) : base(meteorMoveModel, meteorMove, screenLimits)
        {
            Subscribe();
        }
        
        private void Subscribe()
        {
            MeteorMove.Move += MoveMeteor;
        }
    }
}