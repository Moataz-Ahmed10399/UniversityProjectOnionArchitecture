using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Models;

namespace University.Application.Interface
{
    public interface IEmployeeService
    {
            //  Students
            public void AddStudent(Student student);
            public void UpdateStudent(Student student);
            public void DeactivateStudent(int studentId); // Inactive بدل ما نمسح
            public void DeleteStudent(int studentId);     // مسح كامل لو محتاج
            public Student GetStudentDetails(int studentId);
            public List<Student> GetAllStudents();
            public List<Student> SearchStudents(string keyword);

            //  Professors
            public void AddProfessor(Professor professor);
            public void UpdateProfessor(Professor professor);
            public void DeactivateProfessor(int professorId);
            public void DeleteProfessor(int professorId);
            public List<Professor> SearchProfessors(string keyword);
            public void AssignCourseToProfessor(int professorId, int courseId);

            //  Courses
            public void AddCourse(Course course);
            public void UpdateCourse(Course course);
            public void DeactivateCourse(int courseId);
            public void DeleteCourse(int courseId);
            public List<Course> GetAllCourses();
            public List<Course> SearchCourses(string keyword);

            //  Departments
            public void AddDepartment(Department department);
            public void UpdateDepartment(Department department);
            public List<Department> GetAllDepartmentsWithDetails();

            public int Save(); 

    }
}
