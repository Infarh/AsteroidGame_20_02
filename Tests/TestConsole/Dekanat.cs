using System;
using System.Collections.Generic;
using System.IO;

namespace TestConsole
{
    class Dekanat : Storage<Student>
    {
        public event Action<Student> ExelentStudentAdded;

        public Dekanat()
        {
            NewItemAdded += OnNewItemAdded;
        }

        private void OnNewItemAdded(Student student)
        {
            if(student.AverageRating > 4.5)
                ExelentStudentAdded?.Invoke(student);
        }

        public override void SaveToFile(string FileName)
        {
            //using(var file_stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None))
            //using (var writer = new StreamWriter(file_stream))
            //{
            //    // Работа с файлом на запись
            //}

            using (var file_writer = File.CreateText(FileName))
                foreach (var student in _Items)
                {
                    file_writer.Write(student.Name);
                    if (student.Ratings.Count > 0)
                    {
                        var ratings_string = string.Join(",", student.Ratings);
                        file_writer.Write($",{ratings_string}");
                    }

                    file_writer.WriteLine();
                }
        }

        public override void LoadFromFile(string FileName)
        {
            //if(!File.Exists(FileName)) return;
            if(!File.Exists(FileName))
                throw new FileNotFoundException("Файл с данными деканата не найден", FileName);

            base.LoadFromFile(FileName);

            //using (var file_stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            //using (var buffer_stream = new BufferedStream(file_stream, 1024 * 1024))
            //using (var reader = new StreamReader(buffer_stream))
            //{

            //}

            using (var file_reader = File.OpenText(FileName))
            {
                while (!file_reader.EndOfStream)
                {
                    var str = file_reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(str)) continue;

                    var data_elements = str.Split(',');
                    if(data_elements.Length == 0) continue;
                    
                    var student = new Student { Name = data_elements[0] };
                    if (data_elements.Length > 1)
                    {
                        var ratings = new List<int>();
                        for(var i = 1; i < data_elements.Length; i++)
                            ratings.Add(int.Parse(data_elements[i]));
                        student.Ratings = ratings;
                    }

                    Add(student);
                }
            }
        }
    }
}
