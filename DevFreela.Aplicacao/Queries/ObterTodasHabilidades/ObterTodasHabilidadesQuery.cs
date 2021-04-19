using DevFreela.Core.DTO;
using MediatR;
using System.Collections.Generic;

namespace DevFreela.Aplicacao.Queries.ObterTodasHabilidades
{
    public class ObterTodasHabilidadesQuery : IRequest<List<HabilidadeDTO>>
    {
    }
}
