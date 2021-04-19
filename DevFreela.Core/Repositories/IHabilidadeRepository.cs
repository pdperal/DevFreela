using DevFreela.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IHabilidadeRepository
    {
        Task<List<HabilidadeDTO>> ObterTodos();
    }
}
