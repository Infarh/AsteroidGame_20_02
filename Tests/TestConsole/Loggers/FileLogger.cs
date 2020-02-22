namespace TestConsole.Loggers
{
    public class FileLogger : Logger
    {
        private int _Index;

        public string FilePath { get; }

        public FileLogger(string FilePath)
        {
            this.FilePath = FilePath;
        }

        public override void Log(string Message)
        {
            System.IO.File.AppendAllText(FilePath, $"{++_Index}:{Message}\r\n");
        }
    }
}