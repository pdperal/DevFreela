using DevFreela.Core.Entidades;
using DevFreela.Core.Repositories;
using DevFreela.Core.Servicos;
using DevFreela.Infra.Persistencia;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.InserirUsuario
{
    public class InserirUsuarioCommandHandler : IRequestHandler<InserirUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IAuthService _authService;
        public InserirUsuarioCommandHandler(IUsuarioRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<int> Handle(InserirUsuarioCommand command, CancellationToken cancellationToken)
        {
            var senhaHash = _authService.GerarSha256Hash(command.Senha);
            var user = new Usuario(command.NomeCompleto, command.Email, command.DataNascimento, senhaHash, command.Role);
            
            await _repository.InserirAsync(user); 

            return user.Id;
        }
    }
}
