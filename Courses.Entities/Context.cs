using Microsoft.EntityFrameworkCore;
using Courses.Entities.Models;

namespace Courses.Entities;
public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<StudyingLecture> StudyingLectures { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);

        #endregion

        #region Students

        builder.Entity<Student>().ToTable("students");
        builder.Entity<Student>().HasKey(x => x.Id);

        #endregion

        #region Teachers

        builder.Entity<Teacher>().ToTable("teachers");
        builder.Entity<Teacher>().HasKey(x => x.Id);

        #endregion

        #region Subjects

        builder.Entity<Subject>().ToTable("subjects");
        builder.Entity<Subject>().HasKey(x => x.Id);

        #endregion

        #region Courses

        builder.Entity<Course>().ToTable("courses");
        builder.Entity<Course>().HasKey(x => x.CourseId);
        builder.Entity<Course>().HasOne(x => x.Subject)
                                    .WithMany(x => x.Courses)
                                    .HasForeignKey(x => x.SubjectId)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Course>().HasOne(x => x.Teacher)
                                    .WithMany(x => x.Courses)
                                    .HasForeignKey(x => x.TeacherId)
                                    .OnDelete(DeleteBehavior.Cascade);                           

        #endregion

        #region Lectures

        builder.Entity<Lecture>().ToTable("lectures");
        builder.Entity<Lecture>().HasKey(x => x.LectureId);
        builder.Entity<Lecture>().HasOne(x => x.Course)
                                    .WithMany(x => x.Lectures)
                                    .HasForeignKey(x => x.CourseId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region StydyingLectures

        builder.Entity<StudyingLecture>().ToTable("");
        builder.Entity<StudyingLecture>().HasKey(x => x.LectureId);
        builder.Entity<StudyingLecture>().HasKey(x => x.StudentId);
        builder.Entity<StudyingLecture>().HasOne(x => x.Lecture)
                                    .WithMany(x => x.StudyingLectures)
                                    .HasForeignKey(x => x.LectureId)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<StudyingLecture>().HasOne(x => x.Student)
                                    .WithMany(x => x.StudyingLectures)
                                    .HasForeignKey(x => x.StudentId)
                                    .OnDelete(DeleteBehavior.Cascade);                            

        #endregion

        #region StudentCourses

        builder.Entity<StudentCourse>().ToTable("");
        builder.Entity<StudentCourse>().HasKey(x => x.CourseId);
        builder.Entity<StudentCourse>().HasKey(x => x.StudentId);
        builder.Entity<StudentCourse>().HasOne(x => x.Course)
                                    .WithMany(x => x.StudentCourses)
                                    .HasForeignKey(x => x.CourseId)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<StudentCourse>().HasOne(x => x.Student)
                                    .WithMany(x => x.StudentCourses)
                                    .HasForeignKey(x => x.StudentId)
                                    .OnDelete(DeleteBehavior.Cascade); 

        #endregion
    }
}