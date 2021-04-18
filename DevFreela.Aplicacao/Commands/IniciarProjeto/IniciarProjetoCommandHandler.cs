using Dapper;
using DevFreela.Infra.Persistencia;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.IniciarProjeto
{
    public class IniciarProjetoCommandHandler : IRequestHandler<IniciarProjetoCommand>
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public IniciarProjetoCommandHandler(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<Unit> Handle(IniciarProjetoCommand command, CancellationToken cancellationToken)
        {
            var projeto = await _dbContext.Projetos.SingleOrDefaultAsync(x => x.Id == command.Id);

            projeto.Iniciar();

            using var sqlConnection = new SqlConnection(_connectionString);

            var script = "UPDATE Projetos SET Status = @Status, DataInicio = @DataInicio WHERE IdProjeto = @Id";

            sqlConnection.Execute(script,
                new
                {
                    Status = projeto.Status,
                    DataInicio = projeto.DataInicio,
                    Id = command.Id
                });

            return Unit.Value;
        }
    }
}
