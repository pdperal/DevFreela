using Dapper;
using DevFreela.Aplicacao.Servicos.Interfaces;
using DevFreela.Aplicacao.ViewModels;
using DevFreela.Infra.Persistencia;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Aplicacao.Servicos.Implementacoes
{
    public class HabilidadeService : IHabilidadeService
    {
        private readonly DevFreelaDbContext _dbcontext;
        private readonly string _connectionString;

        public HabilidadeService(DevFreelaDbContext dbcontext, IConfiguration configuration)
        {
            _dbcontext = dbcontext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public List<HabilidadeViewModel> ObterTodos()
        {
            using var sqlconnection = new SqlConnection(_connectionString);
            var script = "SELECT Id, Descricao FROM Habilidades";

            return sqlconnection
                .Query<HabilidadeViewModel>(script)
                .ToList();            
        }
    }
}
