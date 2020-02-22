namespace TestConsole.Loggers
{
    interface ILogger
    {
        void Log(string Message);

        void LogInformation(string Message);

        void LogWarning(string Message);

        void LogError(string Message);
    }
}