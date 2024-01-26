using Microsoft.Extensions.Logging;

namespace Library.IOC
{
    public class LogUtilities<T>
    {
        private readonly ILogger<T> _logger;

        public LogUtilities(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            LogWithTimestamp(LogLevel.Information, message);
        }

        public void LogWarning(string message)
        {
            LogWithTimestamp(LogLevel.Warning, message);
        }

        public void LogError(string message)
        {
            LogWithTimestamp(LogLevel.Error, message);
        }

        public void LogDebug(string message)
        {
            LogWithTimestamp(LogLevel.Debug, message);
        }

        private void LogWithTimestamp(LogLevel logLevel, string message)
        {
            DateTime timestamp = DateTime.Now;
            _logger.Log(logLevel, $"{timestamp:yyyy-MM-dd HH:mm:ss} - {message}");
        }
    }
}
