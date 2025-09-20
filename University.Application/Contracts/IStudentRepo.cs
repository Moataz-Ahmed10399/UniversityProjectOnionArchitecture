using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Models;

namespace University.Application.Contracts
{
    public interface IStudentRepo
    {
        public void setcoursetostudent(int studentId, int courseId);
        public List<Course> getstudentcourses(int studentId);
        public decimal getoutstandingfees(int studentId);
        public void PayFees(int studentId, decimal amount);
        public int save();

    }
}
