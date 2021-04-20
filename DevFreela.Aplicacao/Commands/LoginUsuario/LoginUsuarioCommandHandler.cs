using DevFreela.Aplicacao.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Servicos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.LoginUsuario
{
    public class LoginUsuarioCommandHandler : IRequestHandler<LoginUsuarioCommand, LoginUsuarioViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginUsuarioCommandHandler(IAuthService authService, IUsuarioRepository usuarioRepository)
        {
            _authService = authService;
            _usuarioRepository = usuarioRepository;
        }
        public async Task<LoginUsuarioViewModel> Handle(LoginUsuarioCommand command, CancellationToken cancellationToken)
        {
            var senhaHash = _authService.GerarSha256Hash(command.Senha);
            var usuario = await _usuarioRepository.ObterUsuarioAsync(command.Email, senhaHash);

            if (usuario == null)
            {
                return null;
            }
            var token = _authService.GerarJWTToken(usuario.Email, usuario.Role);

            return new LoginUsuarioViewModel(usuario.Email, token);
        }
    }
}
