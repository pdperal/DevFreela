using System;
namespace DevFreela.Aplicacao.InputModels
{
    public class InserirUsuarioInputModel
    {
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
