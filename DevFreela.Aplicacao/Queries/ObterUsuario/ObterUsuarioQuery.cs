using DevFreela.Aplicacao.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplicacao.Queries.ObterUsuario
{
    public class ObterUsuarioQuery : IRequest<UsuarioViewModel>
    {
        public int Id { get; private set; }

        public ObterUsuarioQuery(int id)
        {
            Id = id;
        }
    }
}
