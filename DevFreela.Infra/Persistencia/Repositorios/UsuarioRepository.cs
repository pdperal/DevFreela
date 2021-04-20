using DevFreela.Core.Entidades;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DevFreela.Infra.Persistencia.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public UsuarioRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> ObterAsync(int id)
        {
            return await _dbContext
                .Usuarios
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task InserirAsync(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Usuario> ObterUsuarioAsync(string email, string senhaHash)
        {
            return await _dbContext
                .Usuarios
                .SingleOrDefaultAsync(u => u.Email == email && u.Senha == senhaHash);
        }
    }
}
