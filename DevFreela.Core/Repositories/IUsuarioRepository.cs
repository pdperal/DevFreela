using DevFreela.Core.Entidades;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterAsync(int id);
        Task InserirAsync(Usuario usuario);
    }
}
