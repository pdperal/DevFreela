using DevFreela.Aplicacao.Commands.Inserir;
using DevFreela.Core.Entidades;
using DevFreela.Infra.Persistencia;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.InserirProjeto
{
    public class InserirProjetoCommandHandler : IRequestHandler<InserirProjetoCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        public InserirProjetoCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(InserirProjetoCommand request, CancellationToken cancellationToken)
        {
            var projeto = new Projeto(request.Titulo, request.Descricao, request.IdCliente, request.IdFreelancer, request.CustoTotal);
            await _dbContext.Projetos.AddAsync(projeto);
            await _dbContext.SaveChangesAsync();

            return projeto.Id;
        }
    }
}
