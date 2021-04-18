using DevFreela.Aplicacao.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace DevFreela.Aplicacao.Queries.ObterTodasHabilidades
{
    public class ObterTodasHabilidadesQuery : IRequest<List<HabilidadeViewModel>>
    {
    }
}
