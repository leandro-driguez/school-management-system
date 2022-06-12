
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(SchoolContext context)
    {
        // Entities
        if (!context.AdditionalServices.Any())
        {
            context.AdditionalServices
                .AddRangeAsync(
                    GetAdditionalServices()
                );
        }
        if (!context.BasicMeans.Any())
        {
            context.BasicMeans
                .AddRangeAsync(
                    GetBasicMeans()
                );
        }
        if (!context.Classrooms.Any())
        {
            context.Classrooms
                .AddRangeAsync(
                    GetClassrooms()
                );
        }
        if (!context.Courses.Any())
        {
            context.Courses
                .AddRangeAsync(
                    GetCourses()
                );
        }
        if (!context.CourseGroups.Any())
        {
            context.CourseGroups
                .AddRangeAsync(
                    GetCourseGroups()
                );
        }
        if (!context.Expenses.Any())
        {
            context.Expenses
                .AddRangeAsync(
                    GetExpenses()
                );
        }
        if (!context.Positions.Any())
        {
            context.Positions
                .AddRangeAsync(
                    GetPositions()
                );
        }
        if (!context.Resources.Any())
        {
            context.Resources
                .AddRangeAsync(
                    GetResources()
                );
        }
        if (!context.Schedules.Any())
        {
            context.Schedules
                .AddRangeAsync(
                    GetSchedules()
                );
        }if (!context.SchoolMembers.Any())
        {
            context.SchoolMembers
                .AddRangeAsync(
                    GetSchoolMembers()
                );
        }
        if (!context.Shifts.Any())
        {
            context.Shifts
                .AddRangeAsync(
                    GetShifts()
                );
        }
        if (!context.Students.Any())
        {
            context.Students
                .AddRangeAsync(
                    GetStudents()
                );
        }
        if (!context.Tuitors.Any())
        {
            context.Tuitors
                .AddRangeAsync(
                    GetTuitors()
                );
        }if (!context.Workers.Any())
        {
            context.Workers
                .AddRangeAsync(
                    GetWorkers()
                );
        }
        
        // Records
        if (!context.ExpenseRecords.Any())
        {
            context.ExpenseRecords
                .AddRangeAsync(
                    GetExpenseRecords()
                );
        }
        if (!context.StudentPaymentRecordForAdditionalServices.Any())
        {
            context.StudentPaymentRecordForAdditionalServices
                .AddRangeAsync(
                    GetStudentPaymentRecordForAdditionalServices()
                );
        }
        if (!context.StudentPaymentRecordPerCourseGroups.Any())
        {
            context.StudentPaymentRecordPerCourseGroups
                .AddRangeAsync(
                    GetStudentPaymentRecordPerCourseGroups()
                );
        }
        if (!context.WorkerCourseGroupRecords.Any())
        {
            context.WorkerCourseGroupRecords
                .AddRangeAsync(
                    GetWorkerCourseGroupRecords()
                );
        }
        if (!context.WorkerPayRecordByPositions.Any())
        {
            context.WorkerPayRecordByPositions
                .AddRangeAsync(
                    GetWorkerPayRecordByPositions()
                );
        }
        if (!context.WorkerPayRecordPerCourses.Any())
        {
            context.WorkerPayRecordPerCourses
                .AddRangeAsync(
                    GetWorkerPayRecordPerCourses()
                );
        }

        // Relations  
        if (!context.StudentCourseGroupRelations.Any())
        {
            context.StudentCourseGroupRelations
                .AddRangeAsync(
                    GetStudentCourseGroupRelations()
                );
        }
        if (!context.WorkerCourseRelations.Any())
        {
            context.WorkerCourseRelations
                .AddRangeAsync(
                    GetWorkerCourseRelations()
                );
        }if (!context.WorkerPositionRelations.Any())
        {
            context.WorkerPositionRelations
                .AddRangeAsync(
                    GetWorkerPositionRelations()
                );
        }

        context.SaveChangesAsync();
    }

    #region  Seed Database
    private static AdditionalService[] GetAdditionalServices()
    {
        return new AdditionalService[2];
    }
    private static BasicMean[] GetBasicMeans()
    {
        return new BasicMean[2];
    }
    private static Classroom[] GetClassrooms()
    {
        return new Classroom[]
        {
            new Classroom { Name = "Aula 1", Capacity=30 },
            new Classroom { Name = "Aula 2", Capacity=20 },
            new Classroom { Name = "Aula 3", Capacity=16 }
        };
    }
    private static Course[] GetCourses()
    {
        return new Course[2];
    }
    private static CourseGroup[] GetCourseGroups()
    {
        return new CourseGroup[2];
    }
    private static Expense[] GetExpenses()
    {
        return new Expense[2];
    }
    private static Position[] GetPositions()
    {
        return new Position[2];
    }
    private static Resource[] GetResources()
    {
        return new Resource[2];
    }
    private static Schedule[] GetSchedules()
    {
        return new Schedule[2];
    }
    private static SchoolMember[] GetSchoolMembers()
    {
        return new SchoolMember[]
        {
            new SchoolMember("98012134289", "Leandro", "Rodriguez Llosa", 
                52813412, "Espada No.404 e/ San Benito y Esperanza", new DateTime(2015, 9, 5)),
            new SchoolMember("97081373564", "Laura Victoria", "Riera Perez", 
                52341133, "Jesus Maria No.1242 e/ Fabrica y Aguilar", new DateTime(2022, 6, 11)),
            new SchoolMember( "01022388473", "Marcos M.", "Tirador del Riego", 
                52748081, "7ma-A No.555 e/ 44 y 46", new DateTime(2022, 6, 11))
        };
    }
    private static Shift[] GetShifts()
    {
        return new Shift[2];
    }
    private static Student[] GetStudents()
    {
        return new Student[2];
    }
    private static Tuitor[] GetTuitors()
    {
        return new Tuitor[2];
    }
    private static Worker[] GetWorkers()
    {
        return new Worker[2];
    }
    private static ExpenseRecord[] GetExpenseRecords()
    {
        return new ExpenseRecord[2];
    }
    private static StudentPaymentRecordForAdditionalService[] GetStudentPaymentRecordForAdditionalServices()
    {
        return new StudentPaymentRecordForAdditionalService[2];
    }
    private static StudentPaymentRecordPerCourseGroup[] GetStudentPaymentRecordPerCourseGroups()
    {
        return new StudentPaymentRecordPerCourseGroup[2];
    }
    private static WorkerCourseGroupRecord[] GetWorkerCourseGroupRecords()
    {
        return new WorkerCourseGroupRecord[2];
    }
    private static WorkerPayRecordByPosition[] GetWorkerPayRecordByPositions()
    {
        return new WorkerPayRecordByPosition[2];
    }
    private static WorkerPayRecordPerCourse[] GetWorkerPayRecordPerCourses()
    {
        return new WorkerPayRecordPerCourse[2];
    }
    private static StudentCourseGroupRelation[] GetStudentCourseGroupRelations()
    {
        return new StudentCourseGroupRelation[2];
    }
    private static WorkerCourseRelation[] GetWorkerCourseRelations()
    {
        return new WorkerCourseRelation[2];
    }
    private static WorkerPositionRelation[] GetWorkerPositionRelations()
    {
        return new WorkerPositionRelation[2];
    }
    #endregion
}
