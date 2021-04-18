using DevFreela.Aplicacao.ViewModels;
using MediatR;

namespace DevFreela.Aplicacao.Queries.ObterProjeto
{
    public class ObterProjetoQuery : IRequest<ProjetoDetalheViewModel>
    {
        public int Id { get; private set; }

        public ObterProjetoQuery(int id)
        {
            Id = id;
        } 
    }
}
