using System;
using TMPro;
using UnityEngine;

namespace Game.HUD
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _positionText;
        [SerializeField] private TextMeshProUGUI _rotationText;
        [SerializeField] private TextMeshProUGUI _speedText;
        [SerializeField] private TextMeshProUGUI _laserChargeText;
        [SerializeField] private TextMeshProUGUI _cooldownText;

        public event Action<TextMeshProUGUI> UpdatePositionText;
        public event Action<TextMeshProUGUI> UpdateRotationText;
        public event Action<TextMeshProUGUI> UpdateSpeedText;
        public event Action<TextMeshProUGUI> UpdateLaserChargeText;
        public event Action<TextMeshProUGUI> UpdateCoolDownText;

        private void Update()
        {
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            UpdatePositionText?.Invoke(_positionText);
            UpdateRotationText?.Invoke(_rotationText);
            UpdateSpeedText?.Invoke(_speedText);
            UpdateLaserChargeText?.Invoke(_laserChargeText);
            UpdateCoolDownText?.Invoke(_cooldownText);
        }
    }
}