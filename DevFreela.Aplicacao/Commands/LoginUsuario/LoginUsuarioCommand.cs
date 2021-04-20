using DevFreela.Aplicacao.ViewModels;
using MediatR;

namespace DevFreela.Aplicacao.Commands.LoginUsuario
{
    public class LoginUsuarioCommand : IRequest<LoginUsuarioViewModel>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
