using System;
using UnityEngine;

namespace Modules.UI.Scripts
{
    public class HomeScreen : MonoBehaviour
    {
        private Action _onPlay;
        
        public void Setup(Action onPlay)
        {
            _onPlay = onPlay;
        }
        
        public void Open()
        {
            
        }

        public void Close()
        {
            
        }

        public void OnPlayButtonClicked()
        {
            _onPlay?.Invoke();
        }
    }
}