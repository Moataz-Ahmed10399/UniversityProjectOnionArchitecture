using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Models;

namespace University.Application.Interface
{
    public interface IStudentService
    {
        public void SetCourseTOstudent(int studentId, int courseId); //تسجيل الطالب في مادة

        public List<Course> GetStudentCourses(int studentId);
        public decimal GetOutstandingFees(int studentId);   //عرض المبلغ المستحق على الطالب

        public void PayFees(int studentId, decimal amount); //دفع المصاريف وتغيير حالة الدفع

        public int save();
    }
}
