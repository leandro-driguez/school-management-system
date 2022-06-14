using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure.Configurations;

public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.ToTable("Workers");
        
        builder.HasBaseType<SchoolMember>();

        builder.HasMany(w => w.Services)
            .WithMany(r => r.Providers);
        
        builder.HasMany(w => w.Positions)
            .WithMany(p => p.Workers);
    }
}