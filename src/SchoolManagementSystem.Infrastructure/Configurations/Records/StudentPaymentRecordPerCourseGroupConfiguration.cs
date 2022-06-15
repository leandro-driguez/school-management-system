using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.Infrastructure.Configurations.Records;

public class StudentPaymentRecordPerCourseGroupConfiguration
    : IEntityTypeConfiguration<StudentPaymentRecordPerCourseGroup>
{
    public void Configure(EntityTypeBuilder<StudentPaymentRecordPerCourseGroup> builder)
    {
        throw new NotImplementedException();
    }
}