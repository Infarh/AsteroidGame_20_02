namespace TestConsole.Loggers
{
    public abstract class Logger
    {
        public abstract void Log(string Message);

        public void LogInformation(string Message)
        {
            Log($"[info]:{Message}");
        }

        public void LogWarning(string Message)
        {
            Log($"[warn]:{Message}");

        }

        public void LogError(string Message)
        {
            Log($"[error]:{Message}");
        }
    }
}