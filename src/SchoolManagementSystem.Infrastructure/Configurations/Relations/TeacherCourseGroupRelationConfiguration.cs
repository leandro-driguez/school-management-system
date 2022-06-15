using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Infrastructure.Configurations.Relations;

public class TeacherCourseGroupRelationConfiguration : IEntityTypeConfiguration<TeacherCourseGroupRelation>
{
    public void Configure(EntityTypeBuilder<TeacherCourseGroupRelation> builder)
    {
        throw new NotImplementedException();
    }
}