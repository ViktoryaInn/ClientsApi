using Microsoft.Extensions.Logging;

namespace ClientsApi.Logging
{
    public class FileLoggerOptions
    {
        public string Path { get; set; }
        public LogLevel Level { get; set; }
    }
}