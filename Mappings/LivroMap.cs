using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EFCore.QueryAnalysis.Entities;

namespace EFCore.QueryAnalysis.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");

            builder.Property(p => p.Titulo)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne(p => p.Categoria)
                .WithMany(p => p.Livros)
                .HasForeignKey(p => p.CategoriaID);

            builder.HasOne(p => p.Autor)
                .WithMany(p => p.Livros)
                .HasForeignKey(p => p.AutorID);
        }
    }
}
