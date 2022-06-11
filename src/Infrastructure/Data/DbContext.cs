
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Infrastructure.Data;

public class SchoolContext : DbContext
{
    public SchoolContext (DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public DbSet<SchoolMember> SchoolMembers { get; set; }
    public DbSet<Tuitor> Tuitors { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<BasicMean> BasicMeans { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<CourseGroup> CourseGroups { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<ExpenseRecord> ExpenseRecords { get; set; }
    public DbSet<StudentPaymentRecordForAdditionalService> StudentPaymentRecordForAdditionalServices { get; set; }
    public DbSet<StudentPaymentRecordPerGroup> StudentPaymentRecordPerGroups { get; set; }
    public DbSet<TeacherPayRecordPerCourse> TeacherPayRecordPerCourses { get; set; }
    public DbSet<WorkerPayRecordByPosition> WorkerPayRecordByPositions { get; set; }
    public DbSet<StudentGroupRelation> StudentGroupRelations { get; set; }
    public DbSet<TeacherCourseRelation> TeacherCourseRelations { get; set; }
    public DbSet<TeacherGroupRecord> TeacherGroupRecords { get; set; }
    public DbSet<WorkerPositionRelation> WorkerPositionRelations { get; set; }
    public DbSet<WorkerResourceRelation> WorkerResourceRelations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SchoolMember>().ToTable("SchoolMember");
        modelBuilder.Entity<Tuitor>().ToTable("Tuitor"); 
        modelBuilder.Entity<Classroom>().ToTable("Classroom");
        modelBuilder.Entity<BasicMean>().ToTable("BasicMean");
        modelBuilder.Entity<Position>().ToTable("Position");
        modelBuilder.Entity<Schedule>().ToTable("Schedule");
        modelBuilder.Entity<Expense>().ToTable("Expense");
        modelBuilder.Entity<Student>().ToTable("Student");
        modelBuilder.Entity<Worker>().ToTable("Worker"); 
        modelBuilder.Entity<Resource>().ToTable("Resource");
        modelBuilder.Entity<CourseGroup>().ToTable("CourseGroup");
        modelBuilder.Entity<Course>().ToTable("Course");
        modelBuilder.Entity<ExpenseRecord>().ToTable("ExpenseRecord");
        modelBuilder.Entity<StudentPaymentRecordForAdditionalService>().ToTable("StudentPaymentRecordForAdditionalService");
        modelBuilder.Entity<StudentPaymentRecordPerGroup>().ToTable("StudentPaymentRecordPerGroup");
        modelBuilder.Entity<TeacherPayRecordPerCourse>().ToTable("TeacherPayRecordPerCourse");
        modelBuilder.Entity<WorkerPayRecordByPosition>().ToTable("WorkerPayRecordByPosition");
        modelBuilder.Entity<StudentGroupRelation>().ToTable("StudentGroupRelation");
        modelBuilder.Entity<TeacherCourseRelation>().ToTable("TeacherCourseRelation");
        modelBuilder.Entity<TeacherGroupRecord>().ToTable("TeacherGroupRecord");
        modelBuilder.Entity<WorkerPositionRelation>().ToTable("WorkerPositionRelation");
        modelBuilder.Entity<WorkerResourceRelation>().ToTable("WorkerResourceRelation");

        // modelBuilder.Entity<Student>()
        //         .HasMany<CourseGroup>(s => s.Groups)
        //         .WithMany(c => c.Students).Map();
    }
}
