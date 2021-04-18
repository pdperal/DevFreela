using DevFreela.Core.Entidades;
using DevFreela.Infra.Persistencia;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.InserirComentario
{
    public class InserirComentarioCommandHandler : IRequestHandler<InserirComentarioCommand>
    {
        private readonly DevFreelaDbContext _dbContext;

        public InserirComentarioCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(InserirComentarioCommand command, CancellationToken cancellationToken)
        {
            var comentario = new ComentarioProjeto(command.Conteudo, command.IdProjeto, command.IdUsuario);

            await _dbContext.Comentarios.AddAsync(comentario);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
