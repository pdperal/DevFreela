using DevFreela.Aplicacao.Servicos.Interfaces;
using DevFreela.Aplicacao.ViewModels;
using DevFreela.Infra.Persistencia;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Aplicacao.Servicos.Implementacoes
{
    public class HabilidadeService : IHabilidadeService
    {
        private readonly DevFreelaDbContext _dbcontext;

        public HabilidadeService(DevFreelaDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<HabilidadeViewModel> ObterTodos()
        {
            var habilidades = _dbcontext.Habilidades;

            var habilidadesViewModel = habilidades
                .Select(x => new HabilidadeViewModel(x.Id, x.Descricao))
                .ToList();

            return habilidadesViewModel;
        }
    }
}
