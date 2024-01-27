using UnityEngine;

namespace Library.Utility
{
    public static class DeviceUtility
    {
        public static bool IsTallPhone()
        {
            float screenResolutionRatio = (float)Screen.height / Screen.width;
            return screenResolutionRatio > (1920f/1080f + float.Epsilon);
        }

        public static bool IsTablet()
        {
            float screenResolutionRatio = (float)Screen.height / Screen.width;
            return screenResolutionRatio < (1920f/1080f - float.Epsilon);
        }
    }
}