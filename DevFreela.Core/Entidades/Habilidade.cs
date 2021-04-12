using System;

namespace DevFreela.Core.Entidades
{
    public class Habilidade : EntidadeBase
    {
        public string Description { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Habilidade(string description)
        {
            Description = description;
            DataCriacao = DateTime.Now;
        }
    }
}
