using System;
using System.Diagnostics;

namespace TestConsole.Loggers
{
    public class TraceLogger : DebugLogger, IDisposable
    {
        public override void Log(string Message)
        {
            System.Diagnostics.Trace.WriteLine($">>>>>>> {Message}");
        }

        public override void Log(string Message, string Category)
        {
            System.Diagnostics.Trace.WriteLine($">>>>>>> {Message}", Category);
        }

        public void Dispose()
        {
            Trace.Flush();
        }
    }
}