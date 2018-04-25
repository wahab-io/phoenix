using Microsoft.Extensions.Logging;

namespace Phoenix.Common.Logging
{
    public static class ApplicationLogging
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();
        public static ILogger CreateLogger<T>() => 
            LoggerFactory.CreateLogger<T>();
    }
}