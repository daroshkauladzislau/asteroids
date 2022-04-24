using Infrastructure.Factory.GameFactory;
using TMPro;

namespace Game.HUD.GameHUD
{
    public class HUDController
    {
        private readonly HUD _hud;
        private readonly IGameFactory _gameFactory;

        public HUDController(HUD hud, IGameFactory gameFactory)
        {
            _hud = hud;
            _gameFactory = gameFactory;

            Subscribe();
        }

        private void Subscribe()
        {
            _hud.UpdatePositionText += UpdatePositionText;
            _hud.UpdateRotationText += UpdateRotationText;
            _hud.UpdateSpeedText += UpdateSpeedText;
            _hud.UpdateCoolDownText += UpdateCooldownText;
            _hud.UpdateLaserChargeText += UpdateLaserChargeText;
        }

        private void UpdateLaserChargeText(TextMeshProUGUI text) => 
            text.text = $"Laser charge:{_gameFactory.PlayerShootModel.LaserShootCount}";

        private void UpdateCooldownText(TextMeshProUGUI text) => 
            text.text = $"Cooldown:{_gameFactory.PlayerShootModel.LaserShootDelay}";

        private void UpdateSpeedText(TextMeshProUGUI text) => 
            text.text = $"Speed:{_gameFactory.PlayerMoveModel.SpeedCurveTime * GameConstants.GameConstants.SpeedometerValue}";

        private void UpdateRotationText(TextMeshProUGUI text) => 
            text.text = $"Angle:{_gameFactory.PlayerRotateModel.RotateAngle}";

        private void UpdatePositionText(TextMeshProUGUI text) => 
            text.text = $"X:{_gameFactory.PlayerMoveModel.CurrentPosition.x}, Y:{_gameFactory.PlayerMoveModel.CurrentPosition.y}";
    }
}