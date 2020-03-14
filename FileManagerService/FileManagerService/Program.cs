using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using FileManagerService.Interfaces;
using FileManagerService.Services;

namespace FileManagerService
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(FileService),  // netsh advfirewall firewall add rule name=\"{rule_name}\" dir=in action=allow protocol=TCP localport={port}
                new Uri("http://localhost:8080/FileService"), // netsh http add urlacl url=http://+:{номер порта}/ user=\{имя пользователя}
                new Uri("net.tcp://localhost/FileService"),
                new Uri("net.pipe://localhost/FileService")
            );
            //host.AddDefaultEndpoints(); // Упрощённый вид конфигурации

            host.AddServiceEndpoint(
                typeof(IFileService),
                new BasicHttpBinding(), 
                "http://localhost:8080/FileService");

            host.AddServiceEndpoint(
                typeof(IFileService),
                new NetTcpBinding(), 
                "net.tcp://localhost/FileService");

            host.AddServiceEndpoint(
                typeof(IFileService),
                new NetNamedPipeBinding(),
                "net.pipe://localhost/FileService");

            host.Description.Behaviors.Add(new ServiceMetadataBehavior());

            const string mex_address = "mex";
            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), mex_address);
            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), mex_address);
            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexNamedPipeBinding(), mex_address);

            host.Open();


            Console.WriteLine("Нажмите Enter для выхода...");
            Console.ReadLine();

            host.Close();
            ((IDisposable)host).Dispose();
        }
    }
}
