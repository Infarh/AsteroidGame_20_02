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
            for(var i = 0; i < count; i++)
                result.Add(rnd.Next(2, 6));
            return result;
        }

        static void Main(string[] args)
        {
            var dekanat = new Dekanat();

            var rnd = new Random();
            for(var i = 0; i < 100; i++)
                dekanat.Add(new Student
                {
                    Name = $"Student {i + 1}",
                    Ratings = rnd.GetRandomIntValues(20, 2, 6).ToList() //GetRandomRatings(rnd, 20, 50)
                });

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

            foreach (var std in dekanat2)
                Console.WriteLine(std);

            var average_rating = dekanat2.Average(s => s.AverageRating);
            var sum_average_rating = dekanat2.Sum(s => s.AverageRating);

            var random_student_name = rnd.NextValue("Иванов", "Петров", "Сидоров");

            var random_rating = rnd.NextValue(2, 3, 4, 5);

            Console.ReadLine();
        }
    }
}
