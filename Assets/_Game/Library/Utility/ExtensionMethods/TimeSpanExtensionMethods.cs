using System;

namespace Library.Utility
{
    public enum TimeSpanTextFormatType
    {
        MinSec,
        HourMinSec,
        HourMin,
        DayHourMin,
        DayHour
    }
    
    public static class TimeSpanExtensionMethods
    {
        public static string ToFormattedText(this TimeSpan timeSpan, TimeSpanTextFormatType textFormatType, string completedString = "Completed")
        {
            if (timeSpan.Seconds <= 0f)
            {
                return completedString;
            }
            
            switch (textFormatType)
            {
                case TimeSpanTextFormatType.MinSec:
                    return $"{timeSpan.Minutes.ToString()}:{timeSpan.Minutes.ToString()}";
                case TimeSpanTextFormatType.HourMinSec:
                    return $"{timeSpan.Hours.ToString()}:{timeSpan.Minutes.ToString()}:{timeSpan.Minutes.ToString()}";
                case TimeSpanTextFormatType.HourMin:
                    return $"{timeSpan.Hours.ToString()}h {timeSpan.Minutes.ToString()}m";
                case TimeSpanTextFormatType.DayHourMin:
                    return $"{timeSpan.Days.ToString()}d {timeSpan.Hours.ToString()}h {timeSpan.Minutes.ToString()}m";
                case TimeSpanTextFormatType.DayHour:
                    return $"{timeSpan.Days.ToString()}d {timeSpan.Hours.ToString()}h";
                default:
                    return default;
            }
        }
    }
}