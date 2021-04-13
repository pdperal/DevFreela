using System;

namespace DevFreela.Core.Entidades
{
    public class Habilidade : EntidadeBase
    {
        public string Descricao { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Habilidade(string descricao)
        {
            Descricao = descricao;
            DataCriacao = DateTime.Now;
        }
    }
}
