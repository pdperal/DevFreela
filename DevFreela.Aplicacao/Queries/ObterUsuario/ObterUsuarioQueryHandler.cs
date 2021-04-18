using DevFreela.Aplicacao.ViewModels;
using DevFreela.Infra.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Queries.ObterUsuario
{
    public class ObterUsuarioQueryHandler : IRequestHandler<ObterUsuarioQuery, UsuarioViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;
        public ObterUsuarioQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UsuarioViewModel> Handle(ObterUsuarioQuery query, CancellationToken cancellationToken)
        {
            var user = await _dbContext
                .Usuarios
                .SingleOrDefaultAsync(u => u.Id == query.Id);

            if (user == null)
            {
                return null;
            }

            return new UsuarioViewModel(user.NomeCompleto, user.Email);
        }
    }
}
