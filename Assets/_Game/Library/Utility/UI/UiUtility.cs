using UnityEngine;
using UnityEngine.UI;

namespace Library.Utility
{
    public static class UiUtility
    {
        public static Vector2 GetAnchorPosOfWorldPos(Vector3 worldPos, Camera mainCamera, CanvasScaler canvasScaler)
        {
            Vector2 viewportPoint = mainCamera.WorldToViewportPoint(worldPos);
            Vector2 anchorPoint = new Vector2(
                canvasScaler.referenceResolution.x * (viewportPoint.x - 0.5f),
                canvasScaler.referenceResolution.y * (viewportPoint.y - 0.5f));
            return anchorPoint;
        }
    }
}