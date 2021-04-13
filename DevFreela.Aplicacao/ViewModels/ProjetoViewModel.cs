using System;

namespace DevFreela.Aplicacao.ViewModels
{
    public class ProjetoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public ProjetoViewModel(int id, string titulo, DateTime dataCriacao)
        {
            Id = id;
            Titulo = titulo;
            DataCriacao = dataCriacao;
        }
    }
}