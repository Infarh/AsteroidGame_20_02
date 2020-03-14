using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIHost.Data;
using WebAPIHost.Models;

namespace WebAPIHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public IEnumerable<Employee> Get() => TestData.Employees;
    }
}