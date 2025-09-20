using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Contracts;
using University.Models;
using University.Models.Enum;

namespace University.Infrastracture
{
    public class StudentRepo : IStudentRepo
    {
        public MyDbContext _Context;

        public StudentRepo(MyDbContext context)
        {
            _Context = context;
        }

        public decimal getoutstandingfees(int studentId)
        {
            var student = _Context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
                throw new Exception("Student not found");

            return student.OutstandingFees;

        }

        //public List<Course> getstudentcourses(int studentId)
        //{
        //    return _Context.StudentCourseProfessors.Where(s => s.StId == studentId).Select(scp => scp.Course).ToList();
        //}


        public void PayFees(int studentId, decimal amount)
        {
            var student = _Context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
                throw new Exception("Student not found");

            if (amount < +0)
                throw new Exception("Amount must be greater than zero");

            if (amount > student.OutstandingFees)
                throw new Exception("Amount is greater than outstanding fees");

            student.OutstandingFees -= amount;

            if (student.OutstandingFees == 0)
                student.paymentstate = Paymentstate.Paid;

            //_Context.SaveChanges();
        }

        public void setcoursetostudent(int studentId, int courseId)
        {

            var student = _Context.Students.FirstOrDefault(s => s.Id == studentId);
            var course = _Context.Courses.FirstOrDefault(c => c.Id == courseId);

            if (student == null || course == null)
                throw new Exception("Student or Course not found.");

            if (student.StudentsCoursesProfessors.Count >= 6)
                throw new Exception("Student cannot enroll in more than 6 courses.");
           
            var scp = new StudentCourseProfessor
            {
                CourseID = courseId,
                StId = studentId,
                ProfID = 0,
                GradeValue = 0
            };

            _Context.StudentCourseProfessors.Add(scp);

            student.OutstandingFees += 500;             //هنا زودنا المصاريف اللي علي الطالب و اكن الماده ب 500 

            //_Context.SaveChanges();

        }
        public int save()
        {
            var ents = _Context.ChangeTracker.Entries();
            return _Context.SaveChanges();
        }
    }
}
