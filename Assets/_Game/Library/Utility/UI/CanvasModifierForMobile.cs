using UnityEngine;
using UnityEngine.UI;

namespace Library.Utility
{
    [RequireComponent(typeof(CanvasScaler))]
    public class CanvasModifierForMobile : MonoBehaviour
    {
        private CanvasScaler CanvasScaler
        {
            get
            {
                if (_canvasScaler != null) return _canvasScaler;
                _canvasScaler = GetComponent<CanvasScaler>();
                return _canvasScaler;
            }
        }
        private CanvasScaler _canvasScaler;

        private void Awake()
        {
            ModifyCanvas();
        }

        private void ModifyCanvas()
        {
            float screenResolutionRatio = (float)Screen.height / Screen.width;
            float modifiedY = screenResolutionRatio * CanvasScaler.referenceResolution.x;
            
            if (DeviceUtility.IsTallPhone())
            {
                // float t = CanvasScaler.referenceResolution.y / modifiedY;
                // CanvasScaler.matchWidthOrHeight = t;
                CanvasScaler.referenceResolution = new Vector2(CanvasScaler.referenceResolution.x, modifiedY);
            }

            if (DeviceUtility.IsTablet())
            {
                CanvasScaler.matchWidthOrHeight = 1f;
            }
        }
    }
}