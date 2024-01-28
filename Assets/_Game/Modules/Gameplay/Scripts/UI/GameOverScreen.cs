using System;
using TMPro;
using UnityEngine;

namespace Modules.Gameplay
{
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
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void OnHomeButtonClicked()
        {
            _onHome?.Invoke();
        }
    }
}