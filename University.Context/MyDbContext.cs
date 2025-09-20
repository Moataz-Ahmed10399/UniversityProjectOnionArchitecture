using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Models;

namespace University.Infrastracture
{
    public class MyDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-SVASVG3\\SQLEXPRESS ; Initial Catalog = UniversityProject ; Integrated Security = true; Encrypt = false");
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourseProfessor> StudentCourseProfessors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BaseUser>()
            //            .HasIndex(u => u.Username)
            //            .IsUnique();

            //modelBuilder.Entity<BaseUser>()
            //            .HasIndex(u => u.Email)
            //            .IsUnique();
            //////////////////////////////////////////////////////////////////
            ///
            // 🔹 خلى كل وريث من BaseUser في جدول مستقل
            //modelBuilder.Entity<Student>().ToTable("Students");
            //modelBuilder.Entity<Professor>().ToTable("Professors");
            //modelBuilder.Entity<Employee>().ToTable("Employees");


            modelBuilder.Entity<Student>()
            .HasIndex(u => u.Username)
            .IsUnique();

            modelBuilder.Entity<Student>()
                        .HasIndex(u => u.Email)
                        .IsUnique();

            modelBuilder.Entity<Professor>()
                        .HasIndex(u => u.Username)
                        .IsUnique();

            modelBuilder.Entity<Professor>()
                        .HasIndex(u => u.Email)
                        .IsUnique();

            modelBuilder.Entity<Employee>()
                        .HasIndex(u => u.Username)
                        .IsUnique();

            modelBuilder.Entity<Employee>()
                        .HasIndex(u => u.Email)
                        .IsUnique();
////////////////////////////////////////////////////////////////////////



            modelBuilder.Entity<StudentCourseProfessor>().HasKey(scp => new { scp.CourseID, scp.ProfID, scp.StId });

            modelBuilder.Entity<StudentCourseProfessor>()
                          .HasOne(scp => scp.Course)
                          .WithMany(c => c.StudentCourseProfessors)
                          .HasForeignKey(scp => scp.CourseID);

            modelBuilder.Entity<StudentCourseProfessor>()
                          .HasOne(scp => scp.Student)
                          .WithMany(c => c.StudentsCoursesProfessors)
                          .HasForeignKey(scp => scp.StId).OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<StudentCourseProfessor>()
                          .HasOne(scp => scp.Professor)
                          .WithMany(c => c.StudentCourseProfessors)
                          .HasForeignKey(scp => scp.ProfID).OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<Department>().HasOne(D => D.Faculty)
                .WithMany(f => f.Departments)
                .HasForeignKey(d => d.FacultyId);

            modelBuilder.Entity<Course>()
                    .HasOne(c => c.Department)
                    .WithMany(d => d.Courses)
                    .HasForeignKey(c => c.DeptId);

            modelBuilder.Entity<Professor>()
                        .HasOne(p => p.Department)
                        .WithMany(d => d.Professors)
                        .HasForeignKey(p => p.DeptId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                         .HasOne(s => s.Department)
                         .WithMany(d => d.Students)
                         .HasForeignKey(s => s.DeptId)
                         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Faculty)
                .WithMany(f => f.Employees)
                .HasForeignKey(e => e.FacultyId);

            modelBuilder.Entity<Student>()
                                .HasOne(s => s.Role)
                                .WithMany(r => r.Students)
                                .HasForeignKey(s => s.RoleId);

            modelBuilder.Entity<Professor>()
                        .HasOne(p => p.Role)
                        .WithMany(r => r.Professors)
                        .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Role)
                        .WithMany(r => r.Employees)
                        .HasForeignKey(e => e.RoleId);
        }

    }
}
