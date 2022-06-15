using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.Infrastructure.Configurations.Records;

public class WorkerPayRecordByPositionConfiguration
    : IEntityTypeConfiguration<WorkerPayRecordByPosition>
{
    public void Configure(EntityTypeBuilder<WorkerPayRecordByPosition> builder)
    {
        throw new NotImplementedException();
    }
}