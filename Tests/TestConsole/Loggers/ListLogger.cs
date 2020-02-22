using System;
using System.Collections.Generic;

namespace TestConsole.Loggers
{
    public class ListLogger : Logger
    {
        private readonly List<string> _Messages = new List<string>();

        //public string[] Messages => _Messages.ToArray();
        public string[] Messages
        {
            get
            {
                return _Messages.ToArray();
            }
        }

        public override void Log(string Message)
        {
            _Messages.Add($"({DateTime.Now}){Message}");
        }
    }
}