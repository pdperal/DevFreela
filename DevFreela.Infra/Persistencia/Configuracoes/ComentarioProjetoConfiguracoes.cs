using DevFreela.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infra.Persistencia.Configuracoes
{
    public class ComentarioProjetoConfiguracoes : IEntityTypeConfiguration<ComentarioProjeto>
    {
        public void Configure(EntityTypeBuilder<ComentarioProjeto> builder)
        {
            builder
                .HasKey(prop => prop.Id);

            builder
                .HasOne(prop => prop.Projeto)
                .WithMany(prop => prop.Comentarios)
                .HasForeignKey(prop => prop.IdProjeto);

            builder
                .HasOne(prop => prop.Usuario)
                .WithMany(prop => prop.Comentarios)
                .HasForeignKey(prop => prop.IdUsuario);
        }
    }
}
