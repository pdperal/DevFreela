using DevFreela.Infra.Persistencia;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.AtualizarProjeto
{
    public class AtualizarProjetoCommandHandler : IRequestHandler<AtualizarProjetoCommand>
    {
        private readonly DevFreelaDbContext _dbContext;

        public AtualizarProjetoCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(AtualizarProjetoCommand command, CancellationToken cancellationToken)
        {
            var projeto = _dbContext.Projetos.SingleOrDefault(x => x.Id == command.Id);

            projeto.Atualizar(command.Titulo, command.Descricao, command.CustoTotal);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
