using DevFreela.Aplicacao.ViewModels;
using DevFreela.Infra.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Queries.ObterTodosProjetos
{
    public class ObterTodosProjetosQueryHandler : IRequestHandler<ObterTodosProjetosQuery, List<ProjetoViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;
        public ObterTodosProjetosQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ProjetoViewModel>> Handle(ObterTodosProjetosQuery query, CancellationToken cancellationToken)
        {
            var projetos = _dbContext.Projetos;
            var projetosModel = await projetos
                .Select(x => new ProjetoViewModel(x.Id, x.Titulo, x.DataCriacao))
                .ToListAsync();

            return projetosModel;
        }

    }
}
