using System;
using System.Collections.Generic;
using System.Linq;
using EmployeesManager.Models;

namespace EmployeesManager.Data
{
    static class TestData
    {
        public static List<Employee> Employees { get; } = Enumerable.Range(1, 100)
           .Select(i => new Employee
           {
               Id = i,
               Name = $"Имя {i}",
               SurName = $"Фамилия {i}",
               Patronymic = $"Отчество {i}",
               DayOfBirth = DateTime.Now.Subtract(TimeSpan.FromDays(365 / 6 * (i + 18)))
           })
           .ToList();

    }
}
