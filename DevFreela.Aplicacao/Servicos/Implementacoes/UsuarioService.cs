using DevFreela.Aplicacao.InputModels;
using DevFreela.Aplicacao.Servicos.Interfaces;
using DevFreela.Aplicacao.ViewModels;
using DevFreela.Core.Entidades;
using DevFreela.Infra.Persistencia;
using System.Linq;

namespace DevFreela.Aplicacao.Servicos.Implementacoes
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UsuarioService(DevFreelaDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public int Inserir(InserirUsuarioInputModel inputModel)
        {
            var user = new Usuario(inputModel.NomeCompleto, inputModel.Email, inputModel.DataNascimento);

            _dbContext.Usuarios.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public UsuarioViewModel ObterUsuario(int id)
        {
            var user = _dbContext.Usuarios.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return new UsuarioViewModel(user.NomeCompleto, user.Email);
        }
    }
}