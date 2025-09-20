using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    public class Department : BaseModel
    {
        public int FacultyId { get; set; } //forginkey
        public Faculty Faculty { get; set; }//navigation

        public List<Course> Courses { get; set; }
        public List<Professor> Professors { get; set; }
        public List<Student> Students { get; set; }
    }
}
