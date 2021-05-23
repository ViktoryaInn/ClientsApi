using Microsoft.Extensions.Logging;

namespace ClientsApi.Logging
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _path;
        private readonly LogLevel _level;
        
        public FileLoggerProvider(string path, LogLevel level)
        {
            _level = level;
            _path = path;
        }
        
        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_path, _level);
        }
    }
}