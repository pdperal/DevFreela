using DevFreela.Core.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjetoRepository
    {
        Task<List<Projeto>> ObterTodosAsync();
        Task<Projeto> ObterAsync(int id);
        Task<Projeto> ObterDetalhesAsync(int id);
        Task InserirAsync(Projeto projeto);
        Task IniciarAsync(Projeto projeto);
        Task InserirComentarioAsync(ComentarioProjeto comentarioProjeto);
        Task SaveChangesAsync();
    }
}
