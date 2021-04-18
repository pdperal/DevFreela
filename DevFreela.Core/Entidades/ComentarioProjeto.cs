using System;

namespace DevFreela.Core.Entidades
{
    public class ComentarioProjeto : EntidadeBase
    {
        public string Conteudo { get; private set; }
        public int IdProjeto { get; private set; }
        public int IdUsuario { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public Projeto Projeto { get; private set; }
        public Usuario Usuario { get; private set; }

        public ComentarioProjeto(string conteudo, int idProjeto, int idUsuario)
        {
            Conteudo = conteudo;
            IdProjeto = idProjeto;
            IdUsuario = idUsuario;
            DataCriacao = DateTime.Now;
        }
    }
}
