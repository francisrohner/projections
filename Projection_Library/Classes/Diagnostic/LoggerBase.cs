
using System.Drawing;

namespace Projection_Library.Classes.Diagnostic
{
    public abstract class LoggerBase
    {
        public enum LogLevel
        {
            INFO,
            HIGH_INFO,
            WARNING,
            ERROR,
            HIGH_ERROR            
        }
        public Color GetLogLevelColor(LogLevel level)
        {
            if (level == LogLevel.ERROR)
                return Color.Red;
            else if (level == LogLevel.HIGH_ERROR)
                return Color.DarkRed;
            else if (level == LogLevel.WARNING)
                return Color.Orange;
            else if (level == LogLevel.INFO)
                return Color.White;
            else if (level == LogLevel.HIGH_INFO)
                return Color.Blue;

            return Color.White;
        }
        public void Log(string line)
        {
            Log(LogLevel.INFO, line);
        }
        public abstract void Log(LogLevel level, string line);
        
    }
}
