using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.HUD.EndSessionHUD
{
    public class EndSessionHUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _playAgainButton;

        public event Action<TextMeshProUGUI> UpdateScoreText;
        public event Action<Button> PlayAgainButton;

        private void OnEnable()
        {
            UpdateScoreText?.Invoke(_scoreText);
            PlayAgainButton?.Invoke(_playAgainButton);
        }
    }
}

