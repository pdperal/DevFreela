using Dapper;
using DevFreela.Core.Repositories;
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
        private readonly IProjetoRepository _repository;

        public IniciarProjetoCommandHandler(IProjetoRepository repository)
        {
            _repository = repository;            
        }

        public async Task<Unit> Handle(IniciarProjetoCommand command, CancellationToken cancellationToken)
        {
            var projeto = await _repository.ObterAsync(command.Id);
            projeto.Iniciar();

            await _repository.IniciarAsync(projeto);
            
            return Unit.Value;
        }
    }
}
