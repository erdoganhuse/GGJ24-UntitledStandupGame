using System;
using UnityEngine;

namespace Modules.Gameplay
{
    public class HomeScreen : MonoBehaviour
    {
        private Action _onPlay;
        public Action OnRight;
        public Action OnLeft;
        
        public void Setup(Action onPlay)
        {
            _onPlay = onPlay;
        }
        
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void OnPlayButtonClicked()
        {
            _onPlay?.Invoke();
        }

        public void OnRightButtonClicked()
        {
            OnRight?.Invoke();
        }
        public void OnLeftButtonClicked()
        {
            OnLeft?.Invoke();
        }
    }
}