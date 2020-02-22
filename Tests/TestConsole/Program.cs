using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Loggers;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            //TraceLogger trace_logger = null;
            //try
            //{
            //    trace_logger = new TraceLogger();
            //    trace_logger.Log("123");
            //}
            //finally
            //{
            //    trace_logger.Dispose();
            //}

            using(var trace_logger = new TraceLogger())
                trace_logger.Log("123");

            //Logger logger = new ListLogger();
            //Logger logger = new FileLogger("program.log");
            //Logger logger = new VisualStudioOutputLogger();
            Logger logger = new TraceLogger();
            Trace.Listeners.Add(new TextWriterTraceListener("trace.log"));

            var critical_logger = new ListLogger();
            var student_logger = new Student { Name = "Иванов" };
            var student_clone = (Student) student_logger.Clone();

            ((ILogger)student_logger).LogError("Error!");

            DoSomeCriticalWork(student_logger);

            logger.LogInformation("Start program");

            for (var i = 0; i < 10; i++)
                logger.LogInformation($"Do some work {i + 1}");

            logger.LogWarning("Завершение работы приложения");

            //var log_message = ((ListLogger)logger).Messages;

            var random = new Random();
            var students = new Student[100];
            for (var i = 0; i < students.Length; i++)
                students[i] = new Student { Name = $"Student {i + 1}", Height = random.Next(150, 211) };

            Array.Sort(students);

            Trace.Flush();
            
            Console.ReadLine();
        }

        public static void DoSomeCriticalWork(ILogger log)
        {
            for (var i = 0; i < 10; i++)
            {
                log.LogInformation($"Do some very important work {i + 1}");
            }
        }
    }

    public class Student : ILogger, IComparable, ICloneable
    {
        private List<string> _Messages = new List<string>();

        public double Height { get; set; } = 175;

        public string Name { get; set; }

        public List<int> Ratings { get; set; } = new List<int>();

        public void Log(string Message)
        {
            Ratings.Add(Message.Length);
            _Messages.Add(Message);
        }

        public void LogInformation(string Message) { Log("Info:" + Message); }

        public void LogWarning(string Message) { Log("Warning:" + Message); }

        //public void LogError(string Message) { Log("Error:" + Message); }
        void ILogger.LogError(string Message) { Log("Error:" + Message); }

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                var other_student = (Student)obj;
                //return StringComparer.OrdinalIgnoreCase.Compare(Name, other_student.Name);
                if (Height > other_student.Height)
                    return +1;
                else if (Height.Equals(other_student.Height))
                    return 0;
                else
                    return -1;
            }
            if (obj is null)
                throw new ArgumentNullException(nameof(obj), "Попытка сравнения студента с пустотой");
            throw new ArgumentException("Попытка сравнения студента с " + obj.GetType().Name, nameof(obj));
        }

        public override string ToString() => $"{Name} - {Height}";

        public object Clone()
        {
            //var new_student = new Student
            //{
            //    _Messages = new List<string>(_Messages),
            //    Height = Height,
            //    Name = Name,
            //    Ratings = new List<int>(Ratings)
            //};

            var new_student = (Student)MemberwiseClone();
            new_student._Messages = new List<string>(_Messages);
            new_student.Ratings = new List<int>(Ratings);

            return new_student;
        }
    }
}
