using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.Infrastructure.Configurations.Records;

public class WorkerPayRecordPerCourseConfiguration 
    : IEntityTypeConfiguration<WorkerPayRecordPerCourse>
{
    public void Configure(EntityTypeBuilder<WorkerPayRecordPerCourse> builder)
    {
        throw new NotImplementedException();
    }
}