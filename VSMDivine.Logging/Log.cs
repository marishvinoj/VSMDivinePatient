using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VSMDivine.Logging
{
    public static class Log
    {
        private static ILogger GetLogger(string sourceFilePath, string memberName, int sourceLineNumber)
        {
            var fileName = Path.GetFileNameWithoutExtension(sourceFilePath);
            var enricher = new ClassAndMethodContextEnricher(fileName, memberName, sourceLineNumber);
            var logger = Serilog.Log.Logger.ForContext(enricher);
            return logger;
        }

        public static void Debug(
            string message,
            [CallerFilePath] string sourceFilePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var logger = GetLogger(sourceFilePath, memberName, sourceLineNumber);
            logger.Debug(message);
        }

        public static void Information(
           string message,
           [CallerFilePath] string sourceFilePath = "",
           [CallerMemberName] string memberName = "",
           [CallerLineNumber] int sourceLineNumber = 0)
        {
            var logger = GetLogger(sourceFilePath, memberName, sourceLineNumber);
            logger.Information(message);
        }

        public static void Information<T0>(
            string message,
            T0 p0,
            [CallerFilePath] string sourceFilePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var logger = GetLogger(sourceFilePath, memberName, sourceLineNumber);
            logger.Information(message, p0);
        }

        public static void Information<T0, T1>(
            string message,
            T0 p0, T1 p1,
            [CallerFilePath] string sourceFilePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var logger = GetLogger(sourceFilePath, memberName, sourceLineNumber);
            logger.Information(message, p0, p1);
        }

        // example of calling methods with multiple parameters (for structured logging)
        public static void Information<T0, T1, T2>(
            string message,
            T0 p0, T1 p1, T2 p2,
            [CallerFilePath] string sourceFilePath = "",
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var logger = GetLogger(sourceFilePath, memberName, sourceLineNumber);
            logger.Information(message, p0, p1, p2);
        }

        public static void Warn(
           string message,
           [CallerMemberName] string memberName = "",
           [CallerFilePath] string sourceFilePath = "",
           [CallerLineNumber] int sourceLineNumber = 0)
        {
            var logger = GetLogger(sourceFilePath, memberName, sourceLineNumber);
            logger.Warning(message);
        }

        public static void Error(
            Exception ex,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var logger = GetLogger(sourceFilePath, memberName, sourceLineNumber);
            logger.Error(ex, message);
        }

        public static void Error(
           string message,
           [CallerMemberName] string memberName = "",
           [CallerFilePath] string sourceFilePath = "",
           [CallerLineNumber] int sourceLineNumber = 0)
        {
            var logger = GetLogger(sourceFilePath, memberName, sourceLineNumber);
            logger.Error(message);
        }

        public static void Fatal(
           string message,
           [CallerMemberName] string memberName = "",
           [CallerFilePath] string sourceFilePath = "",
           [CallerLineNumber] int sourceLineNumber = 0)
        {
            FatalAction();

            var logger = GetLogger(sourceFilePath, memberName, sourceLineNumber);
            logger.Fatal(message);
        }

        public static void Fatal(
            Exception ex,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            FatalAction();

            var logger = GetLogger(sourceFilePath, memberName, sourceLineNumber);
            logger.Fatal(ex, message);
        }

        private static void FatalAction()
        {
            Environment.ExitCode = -1;
        }
    }
}
