
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Infrastructure.Configurations;

namespace SchoolManagementSystem.Infrastructure.Data;

public class SchoolContext : DbContext
{
    public SchoolContext (DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    // Entities
    
    // public DbSet<AdditionalService> AdditionalServices { get; set; }
    
    public DbSet<BasicMean> BasicMeans { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseGroup> CourseGroups { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    
    public DbSet<Position> Positions { get; set; }
    
    public DbSet<Resource> Resources { get; set; }
    
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<SchoolMember> SchoolMembers { get; set; }
    
    public DbSet<Shift> Shifts { get; set; }
    
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Tuitor> Tuitors { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Worker> Workers { get; set; }
    
    // Records
    // public DbSet<ExpenseRecord> ExpenseRecords { get; set; }
    // public DbSet<StudentPaymentRecordForAdditionalService> StudentPaymentRecordForAdditionalServices { get; set; }
    // public DbSet<StudentPaymentRecordPerCourseGroup> StudentPaymentRecordPerCourseGroups { get; set; }
    // public DbSet<WorkerCourseGroupRecord> WorkerCourseGroupRecords { get; set; }
    // public DbSet<WorkerPayRecordByPosition> WorkerPayRecordByPositions { get; set; }
    // public DbSet<WorkerPayRecordPerCourse> WorkerPayRecordPerCourses { get; set; }
    //
    // // Relations
    // public DbSet<StudentCourseGroupRelation> StudentCourseGroupRelations { get; set; }
    // public DbSet<WorkerCourseRelation> WorkerCourseRelations { get; set; }
    // public DbSet<WorkerPositionRelation> WorkerPositionRelations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Entities
        // modelBuilder.ApplyConfiguration(new AdditionalServiceConfiguration());

        modelBuilder.ApplyConfiguration(new BasicMeanConfiguration());
        // modelBuilder.Entity<BasicMean>().ToTable("BasicMean");

        modelBuilder.ApplyConfiguration(new ClassroomConfiguration());
        // modelBuilder.Entity<Classroom>().ToTable("Classroom");

        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        // modelBuilder.Entity<Course>().ToTable("Course");

        modelBuilder.ApplyConfiguration(new CourseGroupConfiguration());
        // modelBuilder.Entity<CourseGroup>().ToTable("CourseGroup");

        modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
        // modelBuilder.Entity<Expense>().ToTable("Expense");

        modelBuilder.ApplyConfiguration(new PositionConfiguration());
        // modelBuilder.Entity<Position>().ToTable("Position");
        
        modelBuilder.ApplyConfiguration(new ResourceConfiguration());
        // modelBuilder.Entity<Resource>().ToTable("Resource");

        modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
        // modelBuilder.Entity<Schedule>().ToTable("Schedule");
        
        modelBuilder.ApplyConfiguration(new SchoolMemberConfiguration());
        // modelBuilder.Entity<SchoolMember>().ToTable("SchoolMember");

        modelBuilder.ApplyConfiguration(new ShiftConfiguration());
        // modelBuilder.Entity<Shift>().ToTable("Shift");

        modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        
        modelBuilder.ApplyConfiguration(new TuitorConfiguration());
        
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        // modelBuilder.Entity<Student>().ToTable("Student");
        // modelBuilder.Entity<Tuitor>().ToTable("Tuitor"); 
        
        modelBuilder.ApplyConfiguration(new WorkerConfiguration());
        // modelBuilder.Entity<Worker>().ToTable("Worker");

        // Records
        // modelBuilder.Entity<ExpenseRecord>().ToTable("ExpenseRecord");
        // modelBuilder.Entity<StudentPaymentRecordForAdditionalService>()
            // .ToTable("StudentPaymentRecordForAdditionalService");
        // modelBuilder.Entity<StudentPaymentRecordPerCourseGroup>()
            // .ToTable("StudentPaymentRecordPerCourseGroup");
        // modelBuilder.Entity<WorkerCourseGroupRecord>().ToTable("WorkerCourseGroupRecord");
        // modelBuilder.Entity<WorkerPayRecordByPosition>().ToTable("WorkerPayRecordByPosition");
        // modelBuilder.Entity<WorkerPayRecordPerCourse>().ToTable("WorkerPayRecordPerCourse");

        // // Relations
        // modelBuilder.Entity<StudentCourseGroupRelation>().ToTable("StudentCourseGroupRelation");
        // modelBuilder.Entity<WorkerCourseRelation>().ToTable("WorkerCourseRelation");
        // modelBuilder.Entity<WorkerPositionRelation>().ToTable("WorkerPositionRelation");

        // modelBuilder.Entity<Student>()
        //         .HasMany<CourseGroup>(s => s.Groups)
        //         .WithMany(c => c.Students).Map();
    }
}
// new branch named Develop