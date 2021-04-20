namespace DevFreela.Aplicacao.ViewModels
{
    public class LoginUsuarioViewModel
    {
        public string Email { get; private set; }
        public string Token { get; private set; }

        public LoginUsuarioViewModel(string email, string token)
        {
            Email = email;
            Token = token;
        }
    }
}
