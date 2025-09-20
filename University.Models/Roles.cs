using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Models.Enum;

namespace University.Models
{
    public class Roles 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public RoleName RoleName { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Professor> Professors { get; set; }
        public List<Student> Students { get; set; }
    }
}
