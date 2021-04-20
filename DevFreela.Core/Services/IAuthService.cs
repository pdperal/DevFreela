namespace DevFreela.Core.Servicos
{
    public interface IAuthService
    {
        string GerarJWTToken(string email, string role);
        string GerarSha256Hash(string senha);
    }
}
