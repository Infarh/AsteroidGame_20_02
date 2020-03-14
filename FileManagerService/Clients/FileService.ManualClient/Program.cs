using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FileService.ManualClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TestClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:8080/FileService"));

            var drives = client.GetDrives();
            foreach (var drive in drives)
                Console.WriteLine(drive);

            Console.WriteLine(new string('-', Console.BufferWidth));

            var files = client.GetFiles(@"c:\123");
            foreach (var file in files)
                Console.WriteLine(file);

            Console.WriteLine("Нажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}
