using System;
using UnityEngine;

namespace Modules.Gameplay
{
    public class InputController : MonoBehaviour
    {
        public event Action<InputKeyType> OnKeyPressed;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W)) { OnKeyPressed?.Invoke(InputKeyType.W); }
            if (Input.GetKeyDown(KeyCode.A)) { OnKeyPressed?.Invoke(InputKeyType.A); }
            if (Input.GetKeyDown(KeyCode.S)) { OnKeyPressed?.Invoke(InputKeyType.S); }
            if (Input.GetKeyDown(KeyCode.D)) { OnKeyPressed?.Invoke(InputKeyType.D); }
            
            if (Input.GetKeyDown(KeyCode.UpArrow)) { OnKeyPressed?.Invoke(InputKeyType.Up); }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) { OnKeyPressed?.Invoke(InputKeyType.Left); }
            if (Input.GetKeyDown(KeyCode.DownArrow)) { OnKeyPressed?.Invoke(InputKeyType.Down); }
            if (Input.GetKeyDown(KeyCode.RightArrow)) { OnKeyPressed?.Invoke(InputKeyType.Right); }
        }
    }
}