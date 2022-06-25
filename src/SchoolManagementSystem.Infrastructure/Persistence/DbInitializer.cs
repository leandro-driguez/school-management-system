
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Infrastructure.Persistence;

public static class DbInitializer
{
    #region Entities for add to other entities

    static Teacher carmen = new Teacher{
        Name = "Carmen",
        LastName = "Gonzalez",
        Address = "Calle Conchita",
        Id = "091283928",
        DateBecomedMember = new DateTime(2012,09,21),
        PhoneNumber = 58981234
    };
    static Teacher juan = new Teacher{
        Name = "Juan",
        LastName = "Rodriguz",
        Address = "Calle Paz",
        Id = "90871238292",
        DateBecomedMember = new DateTime(2015,09,21),
        PhoneNumber = 57891234
    };
    static Tuitor frank = new Tuitor{
        Name = "Frank",
        PhoneNumber = 57881239,
    };
    static Student sasha = new Student{
        Name = "Sasha",
        LastName = "hernand",
        Address = "Calle Victoria",
        Id = "90831243234",
        DateBecomedMember = new DateTime(2019,06,15),
        PhoneNumber = 56781239,
        Founds = 12,
        ScholarityLevel = Domain.Enums.Education.Posgrado,
        Tuitor = frank
    };
    static Student sandra = new Student{
        Name = "Sandra",
        LastName = "Jimenez",
        Address = "Calle Pancha",
        Id = "02293881244",
        DateBecomedMember = new DateTime(2021,08,21),
        PhoneNumber = 59871304,
        Founds = 145,
        ScholarityLevel = Domain.Enums.Education.TecnicoMedio,
        Tuitor = frank
    };
    static Student Hermen = new Student{
        Name = "Hermen",
        LastName = "Cartan",
        Address = "Calle Pencil",
        Id = "98130923454",
        DateBecomedMember = new DateTime(2014,09,28),
        PhoneNumber = 56813049,
        Founds = 102,
        ScholarityLevel = Domain.Enums.Education.Primaria,
        Tuitor = frank
    };
    static Student Rodrigo = new Student{
        Name = "Rodrigo",
        LastName = "Posada",
        Address = "Calle Vento",
        Id = "06871223456",
        DateBecomedMember = new DateTime(2021,06,15),
        PhoneNumber = 57893019,
        Founds = 120,
        ScholarityLevel = Domain.Enums.Education.Secundaria,
        Tuitor = frank
    };
    static Student Carlos = new Student{
        Name = "Carlos",
        LastName = "Yatra",
        Address = "Calle Guntilla",
        Id = "98052378290",
        DateBecomedMember = new DateTime(2019,06,15),
        PhoneNumber = 56781239,
        Founds = 134,
        ScholarityLevel = Domain.Enums.Education.Preuniversitario,
        Tuitor = frank
    };

    static Position director = new Position{
        Name = "director"
    };
    static Position secretaria = new Position{
        Name = "secretaria"
    };
    static Position asistente = new Position{
        Name = "asistente"
    };

    static Course algebra = new Course{
        Name = "Algebra",
        Price =  200,
        Type = "Mates"
    };
    static Course logica = new Course{
        Name = "logica",
        Price =  200,
        Type = "Mates"
    };
    static Course geometria = new Course{
        Name = "geometria",
        Price =  200,
        Type = "Mates"
    };
    static Course historia = new Course{
        Name = "Historia",
        Price =  200,
        Type = "Letras"
    };
        
    static CourseGroup algebralineal = new CourseGroup{
        Name = "AlgebraLineal",
        Course = algebra,
        CourseId = algebra.Id,
        Capacity = 30,
        StartDate = new DateTime(2020,07,01),
        EndDate = new DateTime(2020,09,20),
    };
    static CourseGroup algebra2 = new CourseGroup{
        Name = "Algebra2",
        Course = algebra,
        CourseId = algebra.Id,
        Capacity = 30,
        StartDate = new DateTime(2020,10,02),
        EndDate = new DateTime(2020,12,02),
    };
    static CourseGroup geometriaespacial = new CourseGroup{
        Name = "geometria es",
        Course = geometria,
        CourseId = geometria.Id,
        Capacity = 20,
        StartDate = new DateTime(2021,03,01),
        EndDate = new DateTime(2021,05,20),
    };
    static CourseGroup historiaDelArte = new CourseGroup{
        Name = "historiaDA",
        Course = historia,
        CourseId = historia.Id,
        Capacity = 30,
        StartDate = new DateTime(2022,01,01),
        EndDate = new DateTime(2020,04,09),
    };

    #endregion
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
            context.AddRangeAsync(
                    GetStudents()
                );
            context.AddRangeAsync(
                    GetTeachers()
                );
            context.AddRangeAsync(
                    GetWorkers()
                );
        }
        if (!context.Shifts.Any())
        {
            context.Shifts
                .AddRangeAsync(
                    GetShifts()
                );
        }
        // if (!context.Students.Any())
        // {
        //     context.Students
        //         .AddRangeAsync(
        //             GetStudents()
        //         );
        // }
        // if (!context.Teachers.Any())
        // {
        //     context.Teachers
        //         .AddRangeAsync(
        //             GetTeachers()
        //         );
        // }
        if (!context.Tuitors.Any())
        {
            context.Tuitors
                .AddRangeAsync(
                    GetTuitors()
                );
        }
        // if (!context.Workers.Any())
        // {
        //     context.Workers
        //         .AddRangeAsync(
        //             GetWorkers()
        //         );
        // }
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
                Name = "Aula T1",
                Capacity = 16,
                StartDate = new DateTime(2022, 3, 12),
                EndDate = new DateTime(2022, 5, 12),
                Teacher = new Teacher{ Id="00522627123", Name = "juanito", LastName = "tirador", PhoneNumber = 76444081,
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
            new Student { Id = "123456784012", Name = "Pablo", LastName = "Curbelo Paez", PhoneNumber = 56784392,
                Address = "Pocitos No.23 e/ Czda de Vento y ALmendares", 
                DateBecomedMember = new DateTime(2020, 2, 1),
                Tuitor = new Tuitor { Name = "Elena", PhoneNumber = 54637721 }, Founds = 3, 
                ScholarityLevel = Domain.Enums.Education.Posgrado },
            new Student { Id = "123456789012", Name = "Pablo", LastName = "Curbelo Paez", PhoneNumber = 56784392,
                Address = "Pocitos No.23 e/ Czda de Vento y ALmendares", 
                DateBecomedMember = new DateTime(2020, 2, 1),
                Tuitor = new Tuitor { Name = "Elena", PhoneNumber = 54637721 }, Founds = 3, 
                ScholarityLevel = Domain.Enums.Education.Primaria },
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
            new Teacher { Id = "71022200221", Name = "Teresa", LastName = "Graveran",
                PhoneNumber = 59821123, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2008, 9, 5), CourseGroups  = new List<CourseGroup>()}
        };
    }
    
    private static Worker[] GetWorkers()
    {
        return new Worker[]
        {
            new Worker { Id = "99123100221", Name = "Dario", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) },
            new Worker { Id = "99123160221", Name = "Dario", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) }
        };
    }
    
    private static ExpenseRecord[] GetExpenseRecords()
    {
        return new ExpenseRecord[]{
            new ExpenseRecord { Expense = new Expense { Category = "inmueble", Description = "empty" }, 
                Date = new DateTime(2020), Amount = 1, Value = 200},
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
            Name = "Aula T2",
            Capacity = 16,
            StartDate = new DateTime(2022, 3, 12),
            EndDate = new DateTime(2022, 5, 12),
            Teacher = new Teacher{ Id="00523573122", Name = "marcos", LastName = "tirador", PhoneNumber = 76444081,
                Address = "Calle Cotilla", DateBecomedMember = new DateTime(2020, 5, 14), 
                CourseGroups = new List<CourseGroup>() }
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
        var position = new Position { Name = "director", Workers = new List<Worker>() {
            new Worker { Id = "79082901293", Name = "JUan", LastName = "Baez",
                    PhoneNumber = 56471922, Address = "Espada No.404 e/ San Benito y Esperanza", 
                    DateBecomedMember = new DateTime(2019, 9, 5),
                    Positions = new List<Position>()
                     }, 
        }};
        return new []
        {   
            new WorkerPayRecordByPosition
            {
                Worker = new Worker { Id = "99124297421", Name = "Alfredo", LastName = "Perez",
                    PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                    DateBecomedMember = new DateTime(2015, 9, 5),
                    Positions = new List<Position>() { position}
                     }, 
                Position = position,
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
            Name = "Aula T3",
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
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = algebralineal,
                CourseGroupCourseId = algebralineal.Id,
                CourseGroupId = algebra.Id,
                EndDate = algebralineal.EndDate,
                StartDate = algebralineal.StartDate,
                Student = sasha,
                StudentId = sasha.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = algebralineal,
                CourseGroupCourseId = algebralineal.Id,
                CourseGroupId = algebra.Id,
                EndDate = algebralineal.EndDate,
                StartDate = algebralineal.StartDate,
                Student = Carlos,
                StudentId = Carlos.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = algebralineal,
                CourseGroupCourseId = algebralineal.Id,
                CourseGroupId = algebra.Id,
                EndDate = algebralineal.EndDate,
                StartDate = algebralineal.StartDate,
                Student = Rodrigo,
                StudentId = Rodrigo.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = algebralineal,
                CourseGroupCourseId = algebralineal.Id,
                CourseGroupId = algebra.Id,
                EndDate = algebralineal.EndDate,
                StartDate = algebralineal.StartDate,
                Student = Hermen,
                StudentId = Hermen.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = algebra2,
                CourseGroupCourseId = algebra2.Id,
                CourseGroupId = algebra.Id,
                EndDate = algebra2.EndDate,
                StartDate = algebra2.StartDate,
                Student = Hermen,
                StudentId = Hermen.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = algebra2,
                CourseGroupCourseId = algebra2.Id,
                CourseGroupId = algebra.Id,
                EndDate = algebra2.EndDate,
                StartDate = algebra2.StartDate,
                Student = sandra,
                StudentId = sandra.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = historiaDelArte,
                CourseGroupCourseId = historiaDelArte.Id,
                CourseGroupId = algebra.Id,
                EndDate = historiaDelArte.EndDate,
                StartDate = historiaDelArte.StartDate,
                Student = Carlos,
                StudentId = Carlos.Id
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
            },
            new TeacherCourseRelation{
                Teacher = juan,
                TeacherId = juan.Id,
                Course = algebra,
                CourseId = algebra.Id,
                CorrespondingPorcentage = 50
            },
            new TeacherCourseRelation{
                Teacher = juan,
                TeacherId = juan.Id,
                Course = geometria,
                CourseId = geometria.Id,
                CorrespondingPorcentage = 50
            },
            new TeacherCourseRelation{
                Teacher = carmen,
                TeacherId = carmen.Id,
                Course = historia,
                CourseId = historia.Id,
                CorrespondingPorcentage = 40
            }
        };
    }
    
    private static TeacherCourseGroupRelation[] GetTeacherCourseGroupRelations()
    {
        var courseGroup = new CourseGroup
        {
            Course = new Course { Name = "Transito 101", Price = 1000, Type = "Transito" },
            Name = "Aula T4",
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
            },
            new TeacherCourseGroupRelation
            {
                CourseGroup = algebralineal,
                CourseGroupId = algebralineal.Id,
                StartDate = algebralineal.StartDate,
                EndDate = algebralineal.EndDate,
                Teacher = juan,
                TeacherId = juan.Id,
                CourseGroupCourseId = algebra.Id
            },
            new TeacherCourseGroupRelation
            {
                CourseGroup = algebra2,
                CourseGroupId = algebra2.Id,
                StartDate = algebra2.StartDate,
                EndDate = algebra2.EndDate,
                Teacher = juan,
                TeacherId = juan.Id,
                CourseGroupCourseId = algebra.Id
            },
            new TeacherCourseGroupRelation
            {
                CourseGroup = historiaDelArte,
                CourseGroupId = historiaDelArte.Id,
                StartDate = historiaDelArte.StartDate,
                EndDate = historiaDelArte.EndDate,
                Teacher = carmen,
                TeacherId = carmen.Id,
                CourseGroupCourseId = historia.Id
            },
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
            },
            new WorkerPositionRelation{
                Position = director,
                Worker = carmen,
                FixedSalary = 5000
            },
            new WorkerPositionRelation{
                Position = asistente,
                Worker = juan,
                FixedSalary = 3000
            },
             new WorkerPositionRelation{
                Position = secretaria,
                Worker = carmen,
                FixedSalary = 2000
            },
        };
    }
    
#endregion
        
}
