using DevFreela.Aplicacao.Commands.Inserir;
using DevFreela.Core.Entidades;
using DevFreela.Core.Repositories;
using DevFreela.Infra.Persistencia;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Commands.InserirProjeto
{
    public class InserirProjetoCommandHandler : IRequestHandler<InserirProjetoCommand, int>
    {
        private readonly IProjetoRepository _repository;
        public InserirProjetoCommandHandler(IProjetoRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(InserirProjetoCommand request, CancellationToken cancellationToken)
        {
            var projeto = new Projeto(request.Titulo, request.Descricao, request.IdCliente, request.IdFreelancer, request.CustoTotal);
            await _repository.InserirAsync(projeto);

            return projeto.Id;
        }
    }
}
