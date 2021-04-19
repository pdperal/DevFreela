using DevFreela.Aplicacao.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Queries.ObterTodosProjetos
{
    public class ObterTodosProjetosQueryHandler : IRequestHandler<ObterTodosProjetosQuery, List<ProjetoViewModel>>
    {
        private readonly IProjetoRepository _repository;
        public ObterTodosProjetosQueryHandler(IProjetoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ProjetoViewModel>> Handle(ObterTodosProjetosQuery query, CancellationToken cancellationToken)
        {
            var projetos = await _repository.ObterTodosAsync();

            var projetosModel = projetos
                .Select(x => new ProjetoViewModel(x.Id, x.Titulo, x.DataCriacao))
                .ToList();

            return projetosModel;
        }

    }
}
