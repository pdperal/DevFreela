using Dapper;
using DevFreela.Core.DTO;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infra.Persistencia.Repositorios
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        private readonly string _connectionString;
        public HabilidadeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }
        public async Task<List<HabilidadeDTO>> ObterTodos()
        {
            using var sqlconnection = new SqlConnection(_connectionString);
            var script = "SELECT Id, Descricao FROM Habilidades";

            var retorno = await sqlconnection
                .QueryAsync<HabilidadeDTO>(script);

            return retorno.ToList();
        }
    }
}
