using Microsoft.Extensions.Logging;

namespace ClientsApi.Logging
{
    public static class LoggerFactoryExtensions
    {
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string path, LogLevel level) =>
            builder.AddProvider(new FileLoggerProvider(path, level));
    }
}