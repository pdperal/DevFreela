using DevFreela.Core.Entidades;
using DevFreela.Infra.Persistencia;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.InserirUsuario
{
    public class InserirUsuarioCommandHandler : IRequestHandler<InserirUsuarioCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;

        public InserirUsuarioCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(InserirUsuarioCommand command, CancellationToken cancellationToken)
        {
            var user = new Usuario(command.NomeCompleto, command.Email, command.DataNascimento);

            await _dbContext.Usuarios.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
