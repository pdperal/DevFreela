using DevFreela.Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infra.Persistencia
{
    public class DevFreelaDbContext : DbContext
    {
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Habilidade> Habilidades{ get; set; }
        public DbSet<HabilidadeUsuario> HabilidadesUsuario { get; set; }
        public DbSet<ComentarioProjeto> Comentarios { get; set; }

        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {

        }
    }
}
