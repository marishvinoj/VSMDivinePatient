using Serilog;

namespace VSMDivine.Logging
{
    public class LogRegister
    {
        public static void CreateLogger(string appName, string logFilePath)
        {
            var outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] [{CallerFileName}.{CallerMethodName}] {Message}{NewLine}{Exception}";
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(logFilePath, rollOnFileSizeLimit: true, fileSizeLimitBytes: 1_048_576, outputTemplate: outputTemplate)
                //.WriteTo.EventLog(appName, manageEventSource: true, outputTemplate: outputTemplate, logName: appName, restrictedToMinimumLevel: LogEventLevel.Information)
                .Enrich.FromLogContext()
                .CreateLogger();
        }

        public static void DisposeLogger()
        {
            Serilog.Log.CloseAndFlush();
        }
    }
}