
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(SchoolContext context)
    {
        // Look for any students.
        if (context.Classrooms.Any())
        {
            return;   // DB has been seeded
        }

        var classrooms = new Classroom[]
        {
            new Classroom { Capacity=30 },
            new Classroom { Capacity=20 },
            new Classroom { Capacity=16 }
        };

        context.Classrooms.AddRangeAsync(classrooms);
        context.SaveChangesAsync();
    }
}
