using System;
using UnityEngine;

namespace Modules.Gameplay
{
    [RequireComponent(typeof(CanvasGroup))]
    public class HomeScreen : MonoBehaviour
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
        
        private Action _onPlay;
        
        public void Setup(Action onPlay)
        {
            _onPlay = onPlay;
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

        public void OnPlayButtonClicked()
        {
            _onPlay?.Invoke();
        }
    }
}