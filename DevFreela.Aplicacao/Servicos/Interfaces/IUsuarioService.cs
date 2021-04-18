using DevFreela.Aplicacao.InputModels;
using DevFreela.Aplicacao.ViewModels;

namespace DevFreela.Aplicacao.Servicos.Interfaces
{
    public interface IUsuarioService
    {
        int Inserir(InserirUsuarioInputModel inputModel);
        UsuarioViewModel ObterUsuario(int id);
    }
}
