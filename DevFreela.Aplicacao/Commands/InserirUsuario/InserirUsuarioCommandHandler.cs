using DevFreela.Core.Entidades;
using DevFreela.Core.Repositories;
using DevFreela.Infra.Persistencia;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.InserirUsuario
{
    public class InserirUsuarioCommandHandler : IRequestHandler<InserirUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _repository;
        public InserirUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(InserirUsuarioCommand command, CancellationToken cancellationToken)
        {
            var user = new Usuario(command.NomeCompleto, command.Email, command.DataNascimento);
            await _repository.InserirAsync(user); 

            return user.Id;
        }
    }
}
