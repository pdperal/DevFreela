using MediatR;
using System;

namespace DevFreela.Aplicacao.Commands.InserirUsuario
{
    public class InserirUsuarioCommand : IRequest<int>
    {
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Role { get; set; }
    }
}
