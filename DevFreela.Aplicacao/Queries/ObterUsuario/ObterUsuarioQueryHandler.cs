using DevFreela.Aplicacao.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Queries.ObterUsuario
{
    public class ObterUsuarioQueryHandler : IRequestHandler<ObterUsuarioQuery, UsuarioViewModel>
    {
        private readonly IUsuarioRepository _repository;
        public ObterUsuarioQueryHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<UsuarioViewModel> Handle(ObterUsuarioQuery query, CancellationToken cancellationToken)
        {
            var user = await _repository.ObterAsync(query.Id);

            if (user == null)
            {
                return null;
            }

            return new UsuarioViewModel(user.NomeCompleto, user.Email);
        }
    }
}
