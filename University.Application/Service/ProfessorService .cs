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
    public class ProfessorService : IProfessorService
    {
        public IProfessorRepo _professorRepo ;

        public ProfessorService (IProfessorRepo professorRepo)
        {
            _professorRepo = professorRepo ;
        }



        public List<Course> GetProfessorCourses(int professorId)
        {
            return _professorRepo.GetProfessorCourses(professorId);
        }

        public List<Student> GetStudentsForCourse(int professorId, int courseId)
        {
            return _professorRepo.GetStudentsForCourse(professorId, courseId);
        }

        public List<Student> GetUngradedStudents(int professorId, int courseId)
        {
            return _professorRepo.GetUngradedStudents(professorId, courseId);
        }

        public void AssignGrade(int professorId, int studentId, int courseId, double grade)
        {
            // 1) Validation: نطاق الدرجة
            if (grade < 0 || grade > 5)
                throw new Exception("Grade must be between 0 and 5.");

            // 2) نجيب السجل الموجود (Student-Course-Professor)
            var record = _professorRepo.GetStudentCourseProfessor(professorId, studentId, courseId);

            // 3) لو مفيش سجل => إما الطالب مش مسجل في المادة أو البروفسور مش معيّن على المادة
            if (record == null)
                throw new Exception("Record not found. Make sure the student is enrolled in the course and the professor is assigned to it.");

            // 4) (اختياري) تحقق إضافي لو حبيت: تأكد أن الـ ProfID في السجل فعلاً يساوي professorId
            if (record.ProfID != professorId)
                throw new Exception("You are not assigned to grade this student for this course.");

            // 5) نحدّث قيمة الدرجة
            record.GradeValue = grade;

            // 6) نطلب من الـ repo يحفظ التغيير (data-only update)
            _professorRepo.UpdateStudentCourseProfessor(record);
            _professorRepo.Save();
        }

        public int Save()
        {
            return _professorRepo.Save();
        }

    }
}
