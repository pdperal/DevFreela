using DevFreela.Infra.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.FinalizarProjeto
{
    public class FinalizarProjetoCommandHandler : IRequestHandler<FinalizarProjetoCommand>
    {
        private readonly DevFreelaDbContext _dbContext;

        public FinalizarProjetoCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(FinalizarProjetoCommand command, CancellationToken cancellationToken)
        {
            var projeto = await _dbContext.Projetos.SingleOrDefaultAsync(x => x.Id == command.Id);

            projeto.Finalizar();
            _dbContext.SaveChanges();

            return Unit.Value;
        }
    }
}
