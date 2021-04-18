using DevFreela.Aplicacao.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace DevFreela.Aplicacao.Queries.ObterTodosProjetos
{
    public class ObterTodosProjetosQuery : IRequest<List<ProjetoViewModel>>
    {
        public ObterTodosProjetosQuery(string query)
        {
            Query = query;
        }
        public string Query { get; private set; }
    }
}
