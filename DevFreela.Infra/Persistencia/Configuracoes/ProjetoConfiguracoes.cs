using DevFreela.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infra.Persistencia.Configuracoes
{
    public class ProjetoConfiguracoes : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.HasOne(prop => prop.Freelancer)
                .WithMany(prop => prop.ProjetosFreelancer)
                .HasForeignKey(prop => prop.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prop => prop.Cliente)
                .WithMany(prop => prop.ProjetosPublicados)
                .HasForeignKey(prop => prop.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
