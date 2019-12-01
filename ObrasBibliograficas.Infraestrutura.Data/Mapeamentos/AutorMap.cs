using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ObrasBibliograficas.Dominio.Entidades;

namespace ObrasBibliograficas.Infraestrutura.Data.Mapeamentos
{
    public class AutorMap : MapBase<Autor>
    {
        public override void Configure(EntityTypeBuilder<Autor> builder)
        {
            base.Configure(builder);
            builder.ToTable("autor");
            builder.Property(c => c.Nome).IsRequired().HasColumnName("Nome").HasMaxLength(100);
        }
    }
}
