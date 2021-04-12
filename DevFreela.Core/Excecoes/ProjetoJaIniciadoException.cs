using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Excecoes
{
    public class ProjetoJaIniciadoException : Exception
    {
        public ProjetoJaIniciadoException() : base("Projeto já está iniciado.")
        {
        }
    }
}
