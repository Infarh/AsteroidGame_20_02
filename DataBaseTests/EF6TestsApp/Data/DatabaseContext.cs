using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF6TestsApp.Entities;

namespace EF6TestsApp.Data
{
    class DatabaseContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Departament> Departaments { get; set; }

        public DatabaseContext() : this("name=DefaultConnection")
        {

        }

        public DatabaseContext(string ConnectionString) : base(ConnectionString)
        {

        }
    }
}
