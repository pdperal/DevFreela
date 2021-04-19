using Dapper;
using DevFreela.Aplicacao.ViewModels;
using DevFreela.Core.DTO;
using DevFreela.Core.Repositories;
using DevFreela.Infra.Persistencia;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Queries.ObterTodasHabilidades
{
    class ObterTodasHabilidadesQueryHandler : IRequestHandler<ObterTodasHabilidadesQuery, List<HabilidadeDTO>>
    {
        private readonly IHabilidadeRepository _repository;
        public ObterTodasHabilidadesQueryHandler(IHabilidadeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<HabilidadeDTO>> Handle(ObterTodasHabilidadesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObterTodos();
        }
    }
}
