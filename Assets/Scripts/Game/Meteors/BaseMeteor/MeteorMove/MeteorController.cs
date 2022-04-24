using Infrastructure.Services.ScreenLimits;
using UnityEngine;

namespace Game.Meteors.BaseMeteor.MeteorMove
{
    public abstract class MeteorController
    {
        protected readonly MeteorMoveModel MeteorMoveModel;
        protected readonly MeteorMove MeteorMove;
        protected readonly IScreenLimits ScreenLimits;

        protected MeteorController(MeteorMoveModel meteorMoveModel, MeteorMove meteorMove, IScreenLimits screenLimits)
        {
            MeteorMoveModel = meteorMoveModel;
            MeteorMove = meteorMove;
            ScreenLimits = screenLimits;
        }

        protected void MoveMeteor(GameObject meteorObject)
        {
            MeteorMoveModel.Position = meteorObject.transform.position + MeteorMoveModel.Direction.normalized * MeteorMoveModel.Speed * Time.deltaTime;

            if (ScreenLimits.OutOfLimits(MeteorMoveModel.Position))
            {
                Vector3 positionAfterTeleport = ScreenLimits.PositionAfterTeleport(MeteorMoveModel.Position);
                MeteorMoveModel.Position = positionAfterTeleport;
            }
            
            meteorObject.transform.position = MeteorMoveModel.Position;
        }
    }
}