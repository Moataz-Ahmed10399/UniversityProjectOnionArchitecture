using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    public class Faculty : BaseModel
    {
        public List<Employee> Employees { get; set; }
        public List<Department> Departments { get; set; }

    }
}
