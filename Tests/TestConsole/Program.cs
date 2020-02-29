using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            //var simple_array_list = new ArrayList();

            //simple_array_list.Add(42);
            //simple_array_list.Add(new object());
            //simple_array_list.Add(3.14159265358979);
            //simple_array_list.Add("Hello World!");

            //for (var i = 0; i < simple_array_list.Count; i++)
            //{
            //    var value = simple_array_list[i];
            //    if (value is int)
            //    {
            //        int v = (int) value;
            //        Console.WriteLine("Int:{0}", v);
            //    }
            //    else if (value is string)
            //    {
            //        string v = (string)value;
            //        Console.WriteLine("Str:{0}", v);
            //    }
            //    else if (value is double)
            //    {
            //        double v = (double)value;
            //        Console.WriteLine("double:{0}", v);
            //    }
            //}

            //System.Collections.Generic.

            List<Student> students = new List<Student>(45);
            for (var i = 0; i < 46; i++)
                students.Add(new Student());

            var students_to_add = new Student[20];
            for (var i = 0; i < students_to_add.Length; i++)
                students_to_add[i] = new Student();
            students.AddRange(students_to_add);

            students.Capacity = students.Count;

            var new_students_list = new List<Student>(students_to_add);
            students.RemoveAt(5);

            var numbers_list = new List<int>(1000);
            for(var i = 0; i < numbers_list.Capacity; i++)
                numbers_list.Add(i + 72);
            var value_index = numbers_list.BinarySearch(712);

            var strings_list = new List<string>(1000);
            for (var i = 0; i < strings_list.Capacity; i++)
                strings_list.Add($"Message {i + 21}");
            strings_list.Sort((s1, s2) => StringComparer.Ordinal.Compare(s2, s1));

            //var strings_array = strings_list.ToArray();
            //var strings_array = new string[strings_list.Count];
            //strings_list.CopyTo(strings_array, 0);

            var str_value_index = strings_list.BinarySearch("Message 712");
            //strings_list[5] = "qwe";

            //strings_list.ForEach(PrintString);

            const string data_dir_name = "TestData";

            //var total_lines = DataDirectoryProcessor.GetTotalLinesCountStack(data_dir_name);
            //var total_lines = DataDirectoryProcessor.GetTotalLinesCountQueue(data_dir_name);
            //Console.WriteLine("Число строк = {0}", total_lines);

            var test_strings = new string[] { "Hello World!", "123", "123QWE---" };

            
            Dictionary<string, int> str_int_dict = new Dictionary<string, int>();

            str_int_dict.Add("ASD", 1024);
            for(var i = 0; i < test_strings.Length; i++)
                str_int_dict.Add(test_strings[i], test_strings[i].Length);

            foreach (KeyValuePair<string, int> value in str_int_dict) 
                Console.WriteLine("{0} - {1}", value.Key, value.Value);

            var str_123_len = str_int_dict["123"];

            str_int_dict.Remove("123");

            //var str_123_len2 = str_int_dict["123"];

            int str_123_len3;
            if(str_int_dict.TryGetValue("123", out str_123_len3))
                Console.WriteLine(str_123_len3);

            str_int_dict["123"] = 7;
            str_int_dict["123"] = 123;

            StudentsTests.Run();

            Console.ReadLine();
        }

        private static void PrintString(string str) => Console.WriteLine("Str = " + str);
    }
}
