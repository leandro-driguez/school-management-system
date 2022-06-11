
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(SchoolContext context)
    {
        // Look for any students.
        if (!context.Classrooms.Any())
        {
            var classrooms = GetClassrooms();
            context.Classrooms.AddRangeAsync(classrooms);
        }

        if (!context.SchoolMembers.Any())
        {
            var schoolMembers = GetSchoolMembers();
            context.SchoolMembers.AddRangeAsync(schoolMembers);
        }

        context.SaveChangesAsync();
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

    private static SchoolMember[] GetSchoolMembers()
    {
        return new SchoolMember[]
        {
            new SchoolMember { CardId = "98012134289", Name = "Leandro", LastName = "Rodriguez Llosa", 
                PhoneNumber = 52813412, DateBecomedMember = new DateTime(2015, 9, 5), 
                Address = "Espada No.404 e/ San Benito y Esperanza" },
            new SchoolMember { CardId = "97081373564", Name = "Laura Victoria", LastName = "Riera Perez", 
                PhoneNumber = 52341133, DateBecomedMember = new DateTime(2022, 6, 11), 
                Address = "Jesus Maria No.1242 e/ Fabrica y Aguilar"  },
            new SchoolMember { CardId = "01022388473", Name = "Marcos M.", LastName = "Tirador del Riego", 
                PhoneNumber = 52748081, DateBecomedMember = new DateTime(2022, 6, 11), 
                Address = "7ma-A No.555 e/ 44 y 46" }
        };
    }
}
