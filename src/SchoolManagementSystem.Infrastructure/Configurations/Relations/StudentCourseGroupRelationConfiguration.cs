using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Infrastructure.Configurations.Relations;

public class StudentCourseGroupRelationConfiguration : IEntityTypeConfiguration<StudentCourseGroupRelation>
{
    public void Configure(EntityTypeBuilder<StudentCourseGroupRelation> builder)
    {
        throw new NotImplementedException();
    }
}