using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EFCore.QueryAnalysis.Entities;

namespace EFCore.QueryAnalysis.Mappings
{
    public class BibliotecaMap : IEntityTypeConfiguration<Biblioteca>
    {
        public void Configure(EntityTypeBuilder<Biblioteca> builder)
        {
            builder.ToTable("Biblioteca");

            builder.Property(p => p.ID)
                .ValueGeneratedNever();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
    }
}
