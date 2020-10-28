using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepBlazor.Domain.Entities;
using RepBlazor.Infrastructure.Contants;

namespace RepBlazor.Infrastructure.Persistence.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(e => e.ActivityID);

            builder.Property(e => e.Description).HasColumnType(SQLServerDataType.Varchar100).IsRequired();
            builder.Property(e => e.Note).HasColumnType(SQLServerDataType.Varchar100).IsRequired();

            builder.HasOne(e => e.Worksheet).WithMany(p => p.Activities).HasForeignKey(e => e.WorksheetID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}