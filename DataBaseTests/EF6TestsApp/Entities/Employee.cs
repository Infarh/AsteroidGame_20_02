using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6TestsApp.Entities
{
    class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DayOfBirth { get; set; }

        public string Description { get; set; }

        public virtual Departament Departament { get; set; }
    }
}
