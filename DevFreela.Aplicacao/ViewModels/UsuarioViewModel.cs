namespace DevFreela.Aplicacao.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(string nomeCompleto, string email)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
        }

        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
    }
}
