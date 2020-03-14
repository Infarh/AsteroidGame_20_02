using System.Collections.Generic;
using System.Linq;
using WebAPIHost.Models;

namespace WebAPIHost.Data
{
    public class TestData
    {
        public static List<Employee> Employees { get; } = Enumerable.Range(1, 20)
           .Select(i => new Employee
            {
                Id = i,
                Name = $"Сотрудник {i}",
                SurName = $"Фамилия сотрудника {i}",
                Age = 40 - i,
            })
           .ToList();
    }
}
