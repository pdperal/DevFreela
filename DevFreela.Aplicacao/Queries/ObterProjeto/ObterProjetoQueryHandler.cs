using DevFreela.Aplicacao.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infra.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Queries.ObterProjeto
{
    public class ObterProjetoQueryHandler : IRequestHandler<ObterProjetoQuery, ProjetoDetalheViewModel>
    {
        private readonly IProjetoRepository _repository;
        public ObterProjetoQueryHandler(IProjetoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjetoDetalheViewModel> Handle(ObterProjetoQuery query, CancellationToken cancellationToken)
        {
            var projeto = await _repository.ObterAsync(query.Id);           

            if (projeto == null)
            {
                return null;
            }

            var projetoDetailModel = new ProjetoDetalheViewModel(
                projeto.Id,
                projeto.Titulo,
                projeto.Descricao,
                projeto.CustoTotal,
                projeto.DataInicio,
                projeto.DataFinalizado,
                projeto.Cliente.NomeCompleto,
                projeto.Freelancer.NomeCompleto);

            return projetoDetailModel;
        }
    }
}
