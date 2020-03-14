using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApiClient.Models;

namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5001")
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
               .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("api/employees").Result;
            var employsse = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;

            Console.WriteLine("Hello World!");
        }
    }
}
