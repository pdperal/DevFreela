using Dapper;
using DevFreela.Core.Entidades;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Infra.Persistencia.Repositorios
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;
        public ProjetoRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<Projeto> ObterAsync(int id)
        {
            return await _dbContext
                .Projetos
               .Include(p => p.Cliente)
               .Include(p => p.Freelancer)
               .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Projeto>> ObterTodosAsync()
        {
            return await _dbContext.Projetos.ToListAsync();
        }

        public async Task InserirAsync(Projeto projeto)
        {
            await _dbContext.Projetos.AddAsync(projeto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task<Projeto> ObterDetalhesAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task IniciarAsync(Projeto projeto)
        {
            using var sqlConnection = new SqlConnection(_connectionString);

            var script = "UPDATE Projetos SET Status = @Status, DataInicio = @DataInicio WHERE IdProjeto = @Id";

            await sqlConnection.ExecuteAsync(script,
                new
                {
                    Status = projeto.Status,
                    DataInicio = projeto.DataInicio,
                    Id = projeto.Id
                });
        }

        public async Task InserirComentarioAsync(ComentarioProjeto comentarioProjeto)
        {
            await _dbContext.Comentarios.AddAsync(comentarioProjeto);
            await _dbContext.SaveChangesAsync();
        }
    }
}
