using DevFreela.Aplicacao.Commands.RemoverProjeto;
using DevFreela.Core.Repositories;
using DevFreela.Infra.Persistencia;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.DeletarProjeto
{
    public class DeletarProjetoCommandHandler : IRequestHandler<DeletarProjetoCommand>
    {
        private readonly IProjetoRepository _repository;
        public DeletarProjetoCommandHandler(IProjetoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeletarProjetoCommand command, CancellationToken cancellationToken)
        {
            var projeto = await _repository.ObterAsync(command.Id);
            projeto.Cancelar();

            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
