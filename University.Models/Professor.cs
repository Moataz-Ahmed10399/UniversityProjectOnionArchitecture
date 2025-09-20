using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    public class Professor : UserBase
    {

        public int DeptId { get; set; }
        public Department Department { get; set; }

        public List<StudentCourseProfessor> StudentCourseProfessors { get; set; } = new List<StudentCourseProfessor>();
    }
}
