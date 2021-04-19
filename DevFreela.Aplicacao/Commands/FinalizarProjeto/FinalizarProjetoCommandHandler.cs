using DevFreela.Core.Repositories;
using DevFreela.Infra.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.FinalizarProjeto
{
    public class FinalizarProjetoCommandHandler : IRequestHandler<FinalizarProjetoCommand>
    {
        private readonly IProjetoRepository _repository;
        public FinalizarProjetoCommandHandler(IProjetoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(FinalizarProjetoCommand command, CancellationToken cancellationToken)
        {
            var projeto = await _repository.ObterAsync(command.Id);
            projeto.Finalizar();

            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
