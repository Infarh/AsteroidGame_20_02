using System;
using System.Collections.Generic;
using System.Linq;
using TestConsole.Extensions;

namespace TestConsole
{
    static class Program
    {
        private static List<int> GetRandomRatings(Random rnd, int CountMin, int CountMax)
        {
            var count = rnd.Next(CountMin, CountMax + 1);
            var result = new List<int>(count);
            for (var i = 0; i < count; i++)
                result.Add(rnd.Next(2, 6));
            return result;
        }

        private static void OnStudentAdd(Student Student)
        {
            Console.WriteLine("Студент {0} добавлен", Student.Name);
        }

        private static void OnStudentRemoved(Student Student)
        {
            Console.WriteLine("Студент {0} отчислен", Student.Name);
        }

        private static void GoToVoenkomat(Student Student)
        {
            Console.WriteLine("Студент {0} отправлен служить", Student.Name);
        }

        static void Main(string[] args)
        {
            var dekanat = new Dekanat();
            //dekanat.SubscribeToAdd(OnStudentAdd);
            dekanat.SubscribeToRemove(OnStudentRemoved);
            dekanat.SubscribeToRemove(GoToVoenkomat);
            //dekanat.SubscribeToAdd(std => Console.WriteLine("Ещё раз поздравляем студента {0} с поступлением", std.Name));

            dekanat.NewItemAdded += OnStudentAdd;
            dekanat.ExelentStudentAdded += exelent_student => Console.WriteLine("!!! {0} !!!", exelent_student);

            var rnd = new Random();
            for (var i = 0; i < 100; i++)
                dekanat.Add(new Student
                {
                    Name = $"Student {i + 1}",
                    Ratings = rnd.GetRandomIntValues(20, 2, 6).ToList() //GetRandomRatings(rnd, 20, 50)
                });

            dekanat.Add(new Student { Name = "Strange student", Ratings = new List<int> { 5, 5, 5, 4 } });

            const string students_data_file = "students.csv";
            dekanat.SaveToFile(students_data_file);

            var dekanat2 = new Dekanat();
            dekanat2.LoadFromFile(students_data_file);


            var student = new Student
            {
                Name = $"Student",
                Ratings = GetRandomRatings(rnd, 20, 50)
            };

            //var result = student.CompareTo(dekanat);

            //foreach (var std in dekanat2)
            //    Console.WriteLine(std);

            var average_rating = dekanat2.Average(s => s.AverageRating);
            var sum_average_rating = dekanat2.Sum(s => s.AverageRating);

            var random_student_name = rnd.NextValue("Иванов", "Петров", "Сидоров");

            var random_rating = rnd.NextValue(2, 3, 4, 5);

            //StudentProcessor processor = new StudentProcessor(GetIndexedStudentName);
            //StudentProcessor processor = GetIndexedStudentName;

            //var index = 0;
            //foreach (var s in dekanat2)
            //    Console.WriteLine(processor(s, index++));

            //Console.ReadLine();
            //processor = GetAverageStudentRating;

            //index = 0;
            //foreach (var s in dekanat2)
            //    Console.WriteLine(processor(s, index++));

            //Console.ReadLine();
            //ProcessStudents(dekanat2, GetIndexedStudentName);

            //Console.ReadLine();
            //ProcessStudents(dekanat2, GetAverageStudentRating);

            //Console.ReadLine();
            //Console.Clear();
            //ProcessStudentsStandard(dekanat2, PrintStudent);

            //var metrics = GetStudentsMetrics(dekanat2, std => std.Name.Length + (int) (student.AverageRating * 10));

            Console.ReadLine();
            var student_to_remove = dekanat.Skip(65).First();
            dekanat.Remove(student_to_remove);

            Console.ReadLine();
        }

        private static void PrintStudent(Student student)
        {
            Console.WriteLine("Студент: {0}", student.Name);
        }

        public static void ProcessStudentsStandard(IEnumerable<Student> Students, Action<Student> action)
        {
            foreach (var s in Students)
            {
                action(s);
            }
        }

        public static int[] GetStudentsMetrics(IEnumerable<Student> Students, Func<Student, int> GetMetric)
        {
            var result = new List<int>();
            foreach (var student in Students)
                result.Add(GetMetric(student));
            return result.ToArray();
        }

        public static void ProcessStudents(IEnumerable<Student> Students, StudentProcessor Processor)
        {
            var index = 0;
            foreach (var s in Students)
                Console.WriteLine(Processor(s, index++));
        }

        private static string GetIndexedStudentName(Student student, int Index)
        {
            return $"{student.Name}[{Index}]";
        }

        public static string GetAverageStudentRating(Student student, int Index)
        {
            return $"[{Index}]:{student.Name} - {student.AverageRating}";
        }
    }

    internal delegate string StudentProcessor(Student Student, int Index);

    internal delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8);
}
