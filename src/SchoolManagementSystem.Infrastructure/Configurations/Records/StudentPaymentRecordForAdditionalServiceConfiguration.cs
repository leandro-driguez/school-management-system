using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.Infrastructure.Configurations.Records;

public class StudentPaymentRecordForAdditionalServiceConfiguration 
    : IEntityTypeConfiguration<StudentPaymentRecordForAdditionalService>
{
    public void Configure(EntityTypeBuilder<StudentPaymentRecordForAdditionalService> builder)
    {
        throw new NotImplementedException();
    }
}