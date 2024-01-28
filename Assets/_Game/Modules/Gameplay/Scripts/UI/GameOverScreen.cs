using System;
using TMPro;
using UnityEngine;

namespace Modules.Gameplay
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameOverScreen : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        private CanvasGroup CanvasGroup
        {
            get
            {
                if (_canvasGroup != null) return _canvasGroup;
                _canvasGroup = GetComponent<CanvasGroup>();
                return _canvasGroup;
            }
        }
        
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI _highScore;

        private Action _onHome;
        
        public void Setup(int score, int highScore, Action onHome)
        {
            _onHome = onHome;
        }

        public void Open()
        {
            CanvasGroup.alpha = 1f;
            CanvasGroup.interactable = true;
        }

        public void Close()
        {
            CanvasGroup.alpha = 0f;
            CanvasGroup.interactable = false;
        }

        public void OnHomeButtonClicked()
        {
            _onHome?.Invoke();
        }
    }
}