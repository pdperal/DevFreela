using DevFreela.Aplicacao.InputModels;
using DevFreela.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace DevFreela.Aplicacao.Servicos.Interfaces
{
    public interface IProjetoService
    {
        List<ProjetoViewModel> ObterTodos(string query);
        ProjetoDetalheViewModel Obter(int id);
        int Inserir(InserirProjetoInputModel inputModel);
        void Atualizar(AtualizarProjetoInputModel inputModel);
        void Deletar(int id);
        void InserirComentario(InserirComentarioInputModel inputmodel);
        void Iniciar(int id);
        void Finalizar(int id);
    }
}
