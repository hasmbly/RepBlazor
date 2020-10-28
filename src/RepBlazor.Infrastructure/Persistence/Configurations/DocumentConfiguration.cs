using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepBlazor.Domain.Entities;
using RepBlazor.Infrastructure.Contants;

namespace RepBlazor.Infrastructure.Persistence.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(e => e.DocumentID);

            builder.Property(e => e.Name).HasColumnType(SQLServerDataType.Varchar100).IsRequired();
        }
    }
}