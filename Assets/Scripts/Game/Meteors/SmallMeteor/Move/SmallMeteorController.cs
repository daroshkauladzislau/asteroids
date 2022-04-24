using Game.Meteors.BaseMeteor.MeteorMove;
using Services.ScreenLimits;
using UnityEngine;

namespace Game.Meteors.SmallMeteor.Move
{
    public class SmallMeteorController : MeteorController
    {
        public SmallMeteorController(MeteorMoveModel meteorMoveModel, MeteorMove meteorMove, IScreenLimits screenLimits) : base(meteorMoveModel, meteorMove, screenLimits)
        {
            Subscribe();
        }
        
        private void Subscribe()
        {
            MeteorMove.Move += MoveMeteor;
        }
    }
}