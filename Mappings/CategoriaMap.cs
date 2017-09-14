using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EFCore.QueryAnalysis.Entities;

namespace EFCore.QueryAnalysis.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.Property(p => p.ID)
                .ValueGeneratedNever();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne(p => p.Biblioteca)
                .WithMany(p => p.Categorias)
                .HasForeignKey(p => p.BibliotecaID);
        }
    }
}
