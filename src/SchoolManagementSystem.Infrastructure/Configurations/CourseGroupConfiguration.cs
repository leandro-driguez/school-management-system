using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure.Configurations;

public class CourseGroupConfiguration : IEntityTypeConfiguration<CourseGroup>
{
    public void Configure(EntityTypeBuilder<CourseGroup> builder)
    {
        throw new NotImplementedException();
    }
}