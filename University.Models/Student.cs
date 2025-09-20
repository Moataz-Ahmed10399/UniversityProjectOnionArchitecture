using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Models.Enum;

namespace University.Models
{
    public class Student : UserBase
    {
        public Paymentstate paymentstate { get; set; } = Paymentstate.Unpaid;
        public decimal OutstandingFees { get; set; } = 0m; // المبلغ المتبقي
        public int DeptId { get; set; }
        public Department Department { get; set; }
        public List<StudentCourseProfessor> StudentsCoursesProfessors { get; set; } = new List<StudentCourseProfessor>();

    }
}
