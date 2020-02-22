namespace TestConsole.Loggers
{
    public class TraceLogger : DebugLogger
    {
        public override void Log(string Message)
        {
            System.Diagnostics.Trace.WriteLine($">>>>>>> {Message}");
        }

        public override void Log(string Message, string Category)
        {
            System.Diagnostics.Trace.WriteLine($">>>>>>> {Message}", Category);
        }
    }
}