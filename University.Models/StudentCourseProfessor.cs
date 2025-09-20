using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    public class StudentCourseProfessor
    {
        public int CourseID { get; set; }
        public Course Course { get; set; }

        public int ProfID { get; set; }
        public Professor Professor { get; set; }

        public int StId { get; set; }
        public Student Student { get; set; }
        [Range(0, 5)]
        public double GradeValue { get; set; }

    }
}
