using System;

namespace DevFreela.Aplicacao.ViewModels
{
    public class ProjetoDetalheViewModel
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public decimal CustoTotal { get; private set; }
        public DateTime? DataInicio { get; private set; }
        public DateTime? DataFim { get; private set; }
        public string ClienteNomeCompleto { get; private set; }
        public string FreelancerNomeCompleto { get; private set; }

        public ProjetoDetalheViewModel(int id, string titulo, string descricao, decimal custoTotal, DateTime? dataInicio, DateTime? dataFim,
            string clienteNomeCompleto, string freelancerNomeCompleto)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            CustoTotal = custoTotal;
            DataInicio = dataInicio;
            DataFim = dataFim;
            ClienteNomeCompleto = clienteNomeCompleto;
            FreelancerNomeCompleto = freelancerNomeCompleto;
        }
    }
}