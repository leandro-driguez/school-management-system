using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Infrastructure.Configurations.Relations;

public class TeacherCourseRelationConfiguration : IEntityTypeConfiguration<TeacherCourseRelation>
{
    public void Configure(EntityTypeBuilder<TeacherCourseRelation> builder)
    {
        throw new NotImplementedException();
    }
}