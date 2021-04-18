using DevFreela.Aplicacao.ViewModels;
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
        private readonly DevFreelaDbContext _dbContext;
        public ObterProjetoQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjetoDetalheViewModel> Handle(ObterProjetoQuery query, CancellationToken cancellationToken)
        {

            var projeto = await _dbContext.Projetos
                .Include(p => p.Cliente)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(x => x.Id == query.Id);

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
