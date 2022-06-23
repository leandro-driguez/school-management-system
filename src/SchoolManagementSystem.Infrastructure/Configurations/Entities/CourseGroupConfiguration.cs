using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure.Configurations;

public class CourseGroupConfiguration : IEntityTypeConfiguration<CourseGroup>
{
    public void Configure(EntityTypeBuilder<CourseGroup> builder)
    {
        builder.HasKey(p => new { p.Id, p.CourseId });

        builder.HasOne(cg => cg.Course)
            .WithMany(t => t.CourseGroups);

        builder.HasOne(cg => cg.Teacher)
            .WithMany(t => t.CourseGroups);

        builder.Property(cg => cg.Capacity)
            .IsRequired();
        
        builder.Property(cg => cg.StartDate)
            .IsRequired();
        
        builder.Property(cg => cg.EndDate);

    }
}