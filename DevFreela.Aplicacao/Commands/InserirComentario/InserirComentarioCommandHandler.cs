using DevFreela.Core.Entidades;
using DevFreela.Core.Repositories;
using DevFreela.Infra.Persistencia;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.InserirComentario
{
    public class InserirComentarioCommandHandler : IRequestHandler<InserirComentarioCommand>
    {
        private readonly IProjetoRepository _repository;
        public InserirComentarioCommandHandler(IProjetoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(InserirComentarioCommand command, CancellationToken cancellationToken)
        {
            var comentario = new ComentarioProjeto(command.Conteudo, command.IdProjeto, command.IdUsuario);

            await _repository.InserirComentarioAsync(comentario);

            return Unit.Value;
        }
    }
}
