using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ClientsApi.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string _path;
        private readonly LogLevel _level;
        private static readonly object Locker = new object();

        public FileLogger(string path, LogLevel level)
        {
            _level = level;
            _path = path;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            if (formatter is null) return;

            lock (Locker)
            {
                File.AppendAllText(_path, formatter(state, exception) + Environment.NewLine);
            }
        }

        public bool IsEnabled(LogLevel logLevel) => logLevel >= _level;

        public IDisposable BeginScope<TState>(TState state) => null;
    }
}