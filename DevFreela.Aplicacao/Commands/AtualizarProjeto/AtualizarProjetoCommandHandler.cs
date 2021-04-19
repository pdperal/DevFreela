using DevFreela.Core.Repositories;
using DevFreela.Infra.Persistencia;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.AtualizarProjeto
{
    public class AtualizarProjetoCommandHandler : IRequestHandler<AtualizarProjetoCommand>
    {
        private readonly IProjetoRepository _repository;
        public AtualizarProjetoCommandHandler(IProjetoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(AtualizarProjetoCommand command, CancellationToken cancellationToken)
        {
            var projeto = await _repository.ObterAsync(command.Id);
            projeto.Atualizar(command.Titulo, command.Descricao, command.CustoTotal);

            await _repository.SaveChangesAsync();
 
            return Unit.Value;
        }
    }
}
