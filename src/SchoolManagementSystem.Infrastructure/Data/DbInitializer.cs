
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(SchoolContext context)
    {
        // // Entities
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
            var expenses = GetExpenses();
            context.Expenses
                .AddRangeAsync(
                    expenses
                );
            Console.WriteLine(expenses[0].Id);
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
            var resources = GetResources();
            
            context.Resources
                .AddRangeAsync(
                    resources
                );
        }
        if (!context.Schedules.Any())
        {
            context.Schedules
                .AddRangeAsync(
                    GetSchedules()
                );
        }
        if (!context.SchoolMembers.Any())
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
        if (!context.Teachers.Any())
        {
            context.Teachers
                .AddRangeAsync(
                    GetTeachers()
                );
        }
        if (!context.Tuitors.Any())
        {
            context.Tuitors
                .AddRangeAsync(
                    GetTuitors()
                );
        }
        if (!context.Workers.Any())
        {
            context.Workers
                .AddRangeAsync(
                    GetWorkers()
                );
        }
        //     
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
        if (!context.WorkerPayRecordByPositions.Any())
        {
            context.WorkerPayRecordByPositions
                .AddRangeAsync(
                    GetWorkerPayRecordByPositions()
                );
        }
        if (!context.TeacherPayRecordPerCourses.Any())
        {
            context.TeacherPayRecordPerCourses
                .AddRangeAsync(
                    GetTeacherPayRecordPerCourses()
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
        if (!context.TeacherCourseGroupRelations.Any())
        {
            context.TeacherCourseGroupRelations
                .AddRangeAsync(
                    GetTeacherCourseGroupRelations()
                );
        }

        if (!context.TeacherCourseRelations.Any())
        {
            context.TeacherCourseRelations
                .AddRangeAsync(
                    GetTeacherCourseRelations()
                );
        }
        if (!context.WorkerPositionRelations.Any())
        {
            context.WorkerPositionRelations
                .AddRangeAsync(
                    GetWorkerPositionRelations()
                );
        }
        
        context.SaveChangesAsync();
    }

    #region Seed Database

    /// <summary>
    ///     
    /// </summary>
    /// <returns></returns>
    private static AdditionalService[] GetAdditionalServices()
    {
        return new []
        {
            new AdditionalService {Worker = new Worker { Id = "99122104222", Name = "Luis",
                LastName = "Guerrero", PhoneNumber = 52372293, 
                Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) }, 
                Resource = new Resource { Name = "libro de Ingles basico", Category = "Cuaderno", Price = 1000, 
                Providers = new List<Worker>() } , WorkerPorcentageProfits = 15}
        };
    }
    
    private static BasicMean[] GetBasicMeans()
    {
        return new []
        {
            new BasicMean{ Type="Sofa", Origin = "MLC", Price = 200 , DevaluationInTime = 10,
                Description = "Sofa para la entrada, de color carmelita" , 
                InaugurationDate = new DateTime(2021,1,4) }
        };
    }
    
    private static Classroom[] GetClassrooms()
    {
        return new Classroom[]
        {
            new Classroom { Name = "Aula 1", Capacity = 30 },
            new Classroom { Name = "Aula 2", Capacity = 20 },
            new Classroom { Name = "Aula 3", Capacity = 16 }
        };
    }
    
    private static Course[] GetCourses()
    {
        return new Course[]
        {
            new Course { Name = "Transito 101", Price = 16, Type = "Transito" },
            new Course { Name = "Transito 102", Price = 18, Type = "Transito" },
            new Course { Name = "Transito 103", Price = 20, Type = "Transito" }
        };
    }
    
    private static CourseGroup[] GetCourseGroups()
    {
        return new CourseGroup[]
        {
            new CourseGroup
            {
                Course = new Course { Name = "Transito 101", Price = 16, Type = "Transito" },
                Capacity = 16,
                StartDate = new DateTime(2022, 3, 12),
                EndDate = new DateTime(2022, 5, 12),
                Teacher = new Teacher{ Id="00522627123", Name = "marcos", LastName = "tirador", PhoneNumber = 76444081,
                    Address = "Calle Cotilla", DateBecomedMember = new DateTime(2020, 5, 14), 
                    CourseGroups = new List<CourseGroup>() }
                // Shifts = new List<Shift>(),
            }
        };
    }
    
    private static Expense[] GetExpenses()
    {
        return new Expense[]
        {
            new Expense { Category = "inmueble", Description = "empty" },
            new Expense { Category = "comida", Description = "empty" },
            new Expense { Category = "pizarras", Description = "empty" },
    
        };
    }
    
    private static Position[] GetPositions()
    {
        return new Position[]
        {
            new Position { Name = "director", Workers = new List<Worker>()},
            new Position { Name = "secretaria", Workers = new List<Worker>() },
            new Position { Name = "asistente", Workers = new List<Worker>() }
        };
    }
    
    private static Resource[] GetResources()
    {   
        return new Resource[]
        {
            new Resource { Name = "libro de mates", Category = "Libros", Price = 100, 
                Providers = new List<Worker>() /* {
                new Worker { Id = "99123100221", Name = "Dario", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) }
                } */
            },
            new Resource { Name = "libro de ingles", Category = "Libros", Price = 100, 
                Providers = new List<Worker>() /* {
                new Worker { Id = "99123149221", Name = "Dario", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) }
                } */
            },
            new Resource { Name = "libro de historia", Category = "Libros", Price = 100, 
                Providers = new List<Worker>() /* {
                new Worker { Id = "99123102721", Name = "Dario", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) }
                } */
            }
        };
    }
    
    private static Schedule[] GetSchedules()
    {
        return new Schedule[3]
        {
            new Schedule 
                { Duration = new TimeOnly(12), StartTime = new TimeOnly(0), DayOfWeek = DayOfWeek.Friday },
            new Schedule 
                { Duration = new TimeOnly(15), StartTime = new TimeOnly(0), DayOfWeek = DayOfWeek.Monday },
            new Schedule
                { Duration = new TimeOnly(20), StartTime = new TimeOnly(0), DayOfWeek = DayOfWeek.Thursday }
        };
    }
    
    private static SchoolMember[] GetSchoolMembers()
    {
        var schoolMember = new SchoolMember { Id = "98012134289", Name = "Leandro", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) };
    
        return new SchoolMember[]
        {
            schoolMember,
            new SchoolMember { Id = "98022134289", Name = "Leandro", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) },
            new SchoolMember { Id = "98012334289", Name = "Leandro", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) }
        };
    }
    
    private static Shift[] GetShifts()
    {
        return new Shift[]
        {
            new Shift
            {
                Classroom = new Classroom { Name = "Aula 1", Capacity = 30 }, Schedule = new Schedule
                    { Duration = new TimeOnly(12), StartTime = new TimeOnly(0), DayOfWeek = DayOfWeek.Friday }
            },
            new Shift
            {
                Classroom = new Classroom { Name = "Aula 2", Capacity = 20 }, Schedule = new Schedule
                    { Duration = new TimeOnly(14), StartTime = new TimeOnly(0), DayOfWeek = DayOfWeek.Monday }
            },
            new Shift
            {
                Classroom = new Classroom { Name = "Aula 3", Capacity = 16 }, Schedule = new Schedule
                    { Duration = new TimeOnly(15), StartTime = new TimeOnly(0), DayOfWeek = DayOfWeek.Tuesday }
            }
    
        };
    }
    
    private static Student[] GetStudents()
    {
        return new Student[2]
        {
            new Student 
            { 
                Id = "123456784012", Name = "Pablo", LastName = "Curbelo Paez", PhoneNumber = 56784392,
                Address = "Pocitos No.23 e/ Czda de Vento y ALmendares", 
                DateBecomedMember = new DateTime(2020, 2, 1),
                Tuitor = new Tuitor { Name = "Elena", PhoneNumber = 54637721 }, Founds = 3, 
                ScholarityLevel = Domain.Enums.Education.Posgrado 
            },
            new Student 
            { 
                Id = "123456789012", Name = "Pablo", LastName = "Curbelo Paez", PhoneNumber = 56784392,
                Address = "Pocitos No.23 e/ Czda de Vento y ALmendares", 
                DateBecomedMember = new DateTime(2020, 2, 1),
                Tuitor = new Tuitor { Name = "Elena", PhoneNumber = 54637721 }, Founds = 3, 
                ScholarityLevel = Domain.Enums.Education.Primaria 
            },
        };
    }
    
    private static Tuitor[] GetTuitors()
    {
        return new Tuitor[]
        {
            new Tuitor { Name = "Josefa", PhoneNumber = 54674982 }, 
            new Tuitor { Name = "Mari", PhoneNumber = 54637121 },
        };
    }
    
    private static Teacher[] GetTeachers()
    {
        return  new Teacher[]
        {
            new Teacher 
            { 
                Id = "71022200221", Name = "Teresa", LastName = "Graveran",
                PhoneNumber = 59821123, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2008, 9, 5), 
                CourseGroups  = new List<CourseGroup>()
                
            }
        };
    }
    
    private static Worker[] GetWorkers()
    {
        return new Worker[]
        {
            new Worker 
            { 
                Id = "99123100221", Name = "Dario", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) 
            },
            new Worker 
            { 
                Id = "99123160221", Name = "Dario", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) 
            }
        };
    }
    
    private static ExpenseRecord[] GetExpenseRecords()
    {
        return new ExpenseRecord[]{
            new ExpenseRecord 
            { 
                Expense = new Expense { Category = "inmueble", Description = "empty" }, 
                Date = new DateTime(2020), Amount = 1, Value = 200
            },
        };
    }
    
    private static StudentPaymentRecordForAdditionalService[] GetStudentPaymentRecordForAdditionalServices()
    {
        var worker = new Worker
        {
            Id = "99197504222", Name = "Luis",
            LastName = "Guerrero", PhoneNumber = 52372293,
            Address = "Espada No.404 e/ San Benito y Esperanza",
            DateBecomedMember = new DateTime(2015, 9, 5)
        };
        var resource = new Resource
        {
            Name = "libro de Ingles basico", Category = "Cuaderno", Price = 1000,
            Providers = new List<Worker>()
        };
        
        return new StudentPaymentRecordForAdditionalService[]
        {
            new StudentPaymentRecordForAdditionalService
            {
                AdditionalService = new AdditionalService
                {
                    Worker = worker,
                    Resource = resource,
                    WorkerPorcentageProfits = 15
                },
                AdditionalServiceResourceId = resource.Id,
                AdditionalServiceWorkerId = worker.Id,
                Student = new Student 
                {
                    Id = "0998765432158", Name = "Pablo", LastName = "Curbelo Paez", 
                    PhoneNumber = 56784392, Address = "Pocitos No.23 e/ Czda de Vento y ALmendares", 
                    DateBecomedMember = new DateTime(2020, 2, 1), Founds = 3,
                    Tuitor = new Tuitor
                    {
                        Name = "Elena", PhoneNumber = 54637721
                    },  
                    ScholarityLevel = Domain.Enums.Education.Primaria 
                },
                Date = new DateTime(2018,12,02)
            }
        };
    }
    
    private static StudentPaymentRecordPerCourseGroup[] GetStudentPaymentRecordPerCourseGroups()
    {
        var course = new Course { Name = "Transito 101", Price = 16, Type = "Transito" };
        
        var courseGroup = new CourseGroup
        {
            Course = course,
            Capacity = 16,
            StartDate = new DateTime(2022, 3, 12),
            EndDate = new DateTime(2022, 5, 12),
            Teacher = new Teacher
            { 
                Id="00523573123", Name = "marcos", LastName = "tirador", PhoneNumber = 76444081,
                Address = "Calle Cotilla", DateBecomedMember = new DateTime(2020, 5, 14), 
                CourseGroups = new List<CourseGroup>() 
            }
        };

        var student = new Student 
        { 
            Id = "93084574542", Name = "Pablo", LastName = "Curbelo Paez", PhoneNumber = 56784392,
            Address = "Pocitos No.23 e/ Czda de Vento y ALmendares", 
            DateBecomedMember = new DateTime(2020, 2, 1),
            Tuitor = new Tuitor { Name = "Elena", PhoneNumber = 54637721 }, Founds = 3, 
            ScholarityLevel = Domain.Enums.Education.Posgrado 
        };
        
        return new []
        {
            new StudentPaymentRecordPerCourseGroup
            {
                CourseGroup = courseGroup, 
                CourseGroupCourseId = course.Id, 
                CourseGroupId = courseGroup.Id, 
                Date = new DateTime(2017,8,12), 
                StudentId = student.Id, 
                Student = student
            }
        };
    }

    private static WorkerPayRecordByPosition[] GetWorkerPayRecordByPositions()
    {
        return new []
        {
            new WorkerPayRecordByPosition
            {
                Worker = new Worker { Id = "99124297421", Name = "Alfredo", LastName = "Perez",
                    PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                    DateBecomedMember = new DateTime(2015, 9, 5) }, 
                Position = new Position { Name = "director", Workers = new List<Worker>()}, 
                Date = new DateTime(2017,2,1), Payment = 1500 
            }
        };
    }
    
    private static TeacherPayRecordPerCourse[] GetTeacherPayRecordPerCourses()
    {
        return new []
        {
            new TeacherPayRecordPerCourse
            {
                Course = new Course
                {
                    Name = "Transito 101", Price = 16, Type = "Transito"
                },
                Teacher =new Teacher 
                { 
                    Id = "95012393872", Name = "Rebeca", LastName = "Portales",
                    PhoneNumber = 59821123, Address = "Espada No.404 e/ San Benito y Esperanza", 
                    DateBecomedMember = new DateTime(2008, 9, 5), 
                    CourseGroups  = new List<CourseGroup>()
                },
                Date = new DateTime(2018,5,23),
                PaidPorcentage =  40
            }
        };
    }
    
    private static StudentCourseGroupRelation[] GetStudentCourseGroupRelations()
    {
        var courseGroup = new CourseGroup
        {
            Course = new Course { Name = "Transito 101", Price = 16, Type = "Transito" },
            Capacity = 16,
            StartDate = new DateTime(2022, 3, 12),
            EndDate = new DateTime(2022, 5, 12),
            Teacher = new Teacher
            { 
                Id="00032834123", Name = "marcos", LastName = "tirador", PhoneNumber = 76444081,
                Address = "Calle Cotilla", DateBecomedMember = new DateTime(2020, 5, 14), 
                CourseGroups = new List<CourseGroup>() 
            }
        };
        var student = new Student
        {
            Id = "08490438573", Name = "Pablo", LastName = "Curbelo Paez", PhoneNumber = 56784392,
            Address = "Pocitos No.23 e/ Czda de Vento y ALmendares",
            DateBecomedMember = new DateTime(2020, 2, 1),
            Tuitor = new Tuitor
            {
                Name = "Elena", PhoneNumber = 54637721
            },
            Founds = 3, ScholarityLevel = Domain.Enums.Education.Posgrado
        };
        return new []
        {
            new StudentCourseGroupRelation
            {
                CourseGroup = courseGroup, 
                CourseGroupId = courseGroup.Id, 
                CourseGroupCourseId = courseGroup.Course.Id, 
                StartDate = new DateTime(2019,4,12), 
                Student = student,
                StudentId = student.Id
            }
        };
    }
    
    private static TeacherCourseGroupRelation[] GetTeacherCourseGroupRelations()
    {
        var courseGroup = new CourseGroup
        {
            Course = new Course { Name = "Transito 101", Price = 1000, Type = "Transito" },
            Capacity = 16,
            StartDate = new DateTime(2022, 3, 12),
            EndDate = new DateTime(2022, 5, 12),
            Teacher = new Teacher
            { 
                Id="65423476345", Name = "marcos", LastName = "tirador", PhoneNumber = 76444081,
                Address = "Calle Cotilla", DateBecomedMember = new DateTime(2020, 5, 14), 
                CourseGroups = new List<CourseGroup>() 
            }
        };
        var teacher = new Teacher
        {
            Id = "78493402348", Name = "Teresa", LastName = "Graveran",
            PhoneNumber = 59821123, Address = "Espada No.404 e/ San Benito y Esperanza",
            DateBecomedMember = new DateTime(2008, 9, 5),
            CourseGroups = new List<CourseGroup>()

        };
        return new []
        {
            new TeacherCourseGroupRelation
            {
                CourseGroup = courseGroup,
                CourseGroupId = courseGroup.Id,
                CourseGroupCourseId = courseGroup.Course.Id,
                Teacher = teacher,
                StartDate = new DateTime(2022,3,21)
            }
        };
    }
    
    private static TeacherCourseRelation[] GetTeacherCourseRelations()
    {
        var teacher = new Teacher
        {
            Id = "75934499884", Name = "Teresa", LastName = "Graveran",
            PhoneNumber = 59821123, Address = "Espada No.404 e/ San Benito y Esperanza",
            DateBecomedMember = new DateTime(2008, 9, 5),
            CourseGroups = new List<CourseGroup>()

        };
        var course = new Course { Name = "Mat PI", Price = 1200, Type = "Matematica" };
        return new []
        {
            new TeacherCourseRelation
            {
                Teacher = teacher,
                TeacherId = teacher.Id,
                Course = course,
                CourseId = course.Id,
                CorrespondingPorcentage = 40
            }
        };
    }
    
    private static WorkerPositionRelation[] GetWorkerPositionRelations()
    {
        return new WorkerPositionRelation[]
        {
            new WorkerPositionRelation
            {
                Position = new Position { Name = "Secretaria", Workers = new List<Worker>()},
                Worker = new Worker 
                { 
                    Id = "83403899900", Name = "Martha", LastName = "Garcia",
                    PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                    DateBecomedMember = new DateTime(2015, 9, 5) 
                },
                FixedSalary = 2000
            }
        };
    }
    
    #endregion
        
}
