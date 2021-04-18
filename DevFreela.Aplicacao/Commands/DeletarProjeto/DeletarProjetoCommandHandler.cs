using DevFreela.Aplicacao.Commands.RemoverProjeto;
using DevFreela.Infra.Persistencia;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.DeletarProjeto
{
    public class DeletarProjetoCommandHandler : IRequestHandler<DeletarProjetoCommand>
    {
        private readonly DevFreelaDbContext _dbContext;

        public DeletarProjetoCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeletarProjetoCommand command, CancellationToken cancellationToken)
        {
            var projeto = _dbContext.Projetos.SingleOrDefault(x => x.Id == command.Id);
            projeto.Cancelar();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
