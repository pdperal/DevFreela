using DevFreela.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infra.Persistencia.Configuracoes
{
    public class UsuarioConfiguracoes : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .HasKey(prop => prop.Id);

            builder
                .HasMany(prop => prop.Habilidades)
                .WithOne()
                .HasForeignKey(prop => prop.IdHabilidade)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
