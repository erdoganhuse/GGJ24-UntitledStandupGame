using System;
using TMPro;
using UnityEngine;

namespace Modules.UI.Scripts
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI _highScore;

        private Action _onHome;
        
        public void Setup(int score, int highScore, Action onHome)
        {
            _onHome = onHome;
        }

        public void Open()
        {
            
        }

        public void Close()
        {
            
        }

        public void OnHomeButtonClicked()
        {
            _onHome?.Invoke();
        }
    }
}