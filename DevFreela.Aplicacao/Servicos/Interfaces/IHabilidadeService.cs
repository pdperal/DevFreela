using DevFreela.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace DevFreela.Aplicacao.Servicos.Interfaces
{
    public interface IHabilidadeService
    {
        List<HabilidadeViewModel> ObterTodos();
    }
}
