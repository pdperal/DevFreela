using Dapper;
using DevFreela.Aplicacao.ViewModels;
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
    class ObterTodasHabilidadesQueryHandler : IRequestHandler<ObterTodasHabilidadesQuery, List<HabilidadeViewModel>>
    {
        private readonly string _connectionString;
        public ObterTodasHabilidadesQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<HabilidadeViewModel>> Handle(ObterTodasHabilidadesQuery request, CancellationToken cancellationToken)
        {
            using var sqlconnection = new SqlConnection(_connectionString);
            var script = "SELECT Id, Descricao FROM Habilidades";

            var retorno = await sqlconnection
                .QueryAsync<HabilidadeViewModel>(script);

            return retorno.ToList();
        }
    }
}
