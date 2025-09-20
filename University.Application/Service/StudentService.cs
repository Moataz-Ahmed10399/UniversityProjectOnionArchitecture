using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Contracts;
using University.Application.Interface;
using University.Models;

namespace University.Application.Service
{
    public class StudentService : IStudentService
    {
        public IStudentRepo _studentRepo;


        public void SetCourseTOstudent(int studentId, int courseId)
        {
            _studentRepo.setcoursetostudent(studentId, courseId);
        }

        public decimal GetOutstandingFees(int studentId)
        {
            return _studentRepo.getoutstandingfees(studentId);
        }

        public List<Course> GetStudentCourses(int studentId)
        {
            return _studentRepo.getstudentcourses(studentId);

        }

        public void PayFees(int studentId, decimal amount)
        {
            _studentRepo.PayFees(studentId, amount);
        }

        public int save()
        {
            return _studentRepo.save();
        }
    }
}
