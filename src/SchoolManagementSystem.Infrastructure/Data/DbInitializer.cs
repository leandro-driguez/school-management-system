
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
        return new Course[]
        {
            new Course { Name = "Transito 101", Price = 16, Type = "Transito"},
            new Course { Name = "Transito 102", Price = 18, Type = "Transito"},
            new Course { Name = "Transito 103", Price = 20, Type = "Transito"}
        };
    }
    private static CourseGroup[] GetCourseGroups()
    {
        return new CourseGroup[]
        {   
            new CourseGroup{
                Course = new Course { Name = "Transito 101", Price = 16, Type = "Transito"},
                Capacity = 16,
                StartDate = new DateTime(2022,3,12),
                EndDate = new DateTime(2022,5,12),
                Teacher = new Worker("00522627123", "marcos", "tirador", 76444081, "Calle Cotilla", new DateTime(2020,5,14)),
                Shifts = new List<Shift>(),
            }
        };
    }
    private static Expense[] GetExpenses()
    {
        return new Expense[]
        {
            new Expense{Category = "inmueble", Description = "empty"},
            new Expense{Category = "comida", Description = "empty"},
            new Expense{Category = "pizarras", Description = "empty"},

        };
    }
    private static Position[] GetPositions()
    {
        return new Position[]
        {
            new Position{Name = "director"},
            new Position{Name = "secretaria"},
            new Position{Name = "asistente"}
        };
    }
    private static Resource[] GetResources()
    {
        return new Resource[3]
        {
            new Resource{ Name = "libro de mates", Category = "Libros", Price = 100},
            new Resource{ Name = "libro de ingles", Category = "Libros", Price = 100},
            new Resource{ Name = "libro de historia", Category = "Libros", Price = 100}
        };
    }
    private static Schedule[] GetSchedules()
    {
        return new Schedule[3]{
            new Schedule{ Duration = new TimeOnly(12), StartTime = new TimeOnly(0), DayOfWeek = DayOfWeek.Friday},
            new Schedule{ Duration = new TimeOnly(15), StartTime = new TimeOnly(0), DayOfWeek = DayOfWeek.Monday},
            new Schedule{ Duration = new TimeOnly(20), StartTime = new TimeOnly(0), DayOfWeek = DayOfWeek.Thursday}
        };
    }
    private static SchoolMember[] GetSchoolMembers()
    {
        var schoolMember = new SchoolMember ("98012134289", "Leandro", "Rodriguez Llosa", 
            52813412, "Espada No.404 e/ San Benito y Esperanza", new DateTime(2015, 9, 5));        
        
        schoolMember.UpdateKey();

        return new SchoolMember[]
        {
            schoolMember,
            new SchoolMember ("98022134289",  "Leandro", "Rodriguez Llosa", 
                52813412, "Espada No.404 e/ San Benito y Esperanza", new DateTime(2015, 9, 5)),
            new SchoolMember ("98012334289",  "Leandro", "Rodriguez Llosa", 
                52813412, "Espada No.404 e/ San Benito y Esperanza", new DateTime(2015, 9, 5))
        };
    }
    private static Shift[] GetShifts()
    {
        return new Shift[]{
            new Shift {ShiftClassroom =  new Classroom{ Name = "Aula 1", Capacity=30 }, ShiftSchedule = new Schedule{ Duration = new TimeOnly(12), StartTime = new TimeOnly(0), DayOfWeek = DayOfWeek.Friday} },
            new Shift {ShiftClassroom =  new Classroom{ Name = "Aula 1", Capacity=30 }, ShiftSchedule = new Schedule{ Duration = new TimeOnly(14), StartTime = new TimeOnly(0), DayOfWeek = DayOfWeek.Monday} },
            new Shift {ShiftClassroom =  new Classroom{ Name = "Aula 1", Capacity=30 }, ShiftSchedule = new Schedule{ Duration = new TimeOnly(15), StartTime = new TimeOnly(0), DayOfWeek = DayOfWeek.Tuesday} }

        };
    }
    private static Student[] GetStudents()
    {
        return new Student[2]{
            new Student("123456784012", "Pablo", "Curbelo Paez", 56784392, "Pocitos No.23 e/ Czda de Vento y ALmendares",new DateTime(2020,2,1),new Tuitor{Name="Elena", PhoneNumber=54637721},3,Domain.Enums.Education.Posgrado),
            new Student("123456789012", "Pablo", "Curbelo Paez", 56784392, "Pocitos No.23 e/ Czda de Vento y ALmendares",new DateTime(2020,2,1),new Tuitor{Name="Elena", PhoneNumber=54637721},3,Domain.Enums.Education.Primaria),
        };
    }
    private static Tuitor[] GetTuitors()
    {
        return new Tuitor[2];
    }
    private static Worker[] GetWorkers()
    {
        return new Worker[]{
            new Worker ("98012137289", "Leandro", "Rodriguez Llosa", 
                52813412, "Espada No.404 e/ San Benito y Esperanza", new DateTime(2015, 9, 5)),
            new Worker ("98012139289", "Leandro", "Rodriguez Llosa", 
                52813412, "Espada No.404 e/ San Benito y Esperanza", new DateTime(2015, 9, 5))
        };
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
