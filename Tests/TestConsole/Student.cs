using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Student : IComparable<Student>, IEquatable<Student>, IEquatable<string>, ICloneable<Student>
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Patronimyc { get; set; }

        public List<int> Ratings { get; set; } = new List<int>();

        public int GroupId { get; set; }

        public double AverageRating
        {
            get
            {
                //return Ratings.Average();
                return Ratings.Sum() / (double) Ratings.Count;
            }
        }

        //public double AverageRating
        //{
        //    get
        //    {
        //        var ratings = Ratings;
        //        if(ratings == null)
        //            throw new InvalidOperationException("Невозможно расcчитать среднюю оценку. Список оценок не задан");
        //        if (ratings.Count == 0)
        //            return double.NaN;

        //        var sum = 0;
        //        for (var i = 0; i < ratings.Count; i++)
        //            sum += ratings[i];
        //        return sum / (double) ratings.Count;
        //    }
        //}

        public bool Equals(Student other)
        {
            return other?.FirstName == FirstName;
            //return (other == null ? null : other.Name) == Name;
            //if (other == null)
            //    return null == Name;
            //else
            //    return other.Name == Name;
        }

        public bool Equals(string other)
        {
            return FirstName == other;
        }

        public override string ToString() => $"[{Id}] {LastName} {FirstName} {Patronimyc} ({GroupId}): {AverageRating:0.##}";

        public int CompareTo(Student other)
        {
            var current_average_rating = AverageRating;
            var other_average_rating = other.AverageRating;

            if (Math.Abs(current_average_rating - other_average_rating) < 0.001)
                return 0;
            if (current_average_rating > other_average_rating)
                return +1;
            else
                return -1;
        }

        public object Clone()
        {
            return new Student
            {
                FirstName = FirstName,
                Ratings = new List<int>(Ratings)
            };
        }

        public Student CloneObject()
        {
            return (Student) Clone();
        }
    }
}
