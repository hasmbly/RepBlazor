using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepBlazor.Domain.Entities;
using RepBlazor.Infrastructure.Contants;

namespace RepBlazor.Infrastructure.Persistence.Configurations
{
    public class WorksheetConfiguration : IEntityTypeConfiguration<Worksheet>
    {
        public void Configure(EntityTypeBuilder<Worksheet> builder)
        {
            builder.HasKey(e => e.WorksheetID);

            builder.Property(e => e.Name).HasColumnType(SQLServerDataType.Varchar100).IsRequired();

            builder.HasOne(e => e.Document).WithMany(p => p.Worksheets).HasForeignKey(e => e.DocumentID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}