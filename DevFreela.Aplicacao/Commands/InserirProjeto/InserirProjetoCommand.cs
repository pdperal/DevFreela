using MediatR;

namespace DevFreela.Aplicacao.Commands.Inserir
{
    public class InserirProjetoCommand : IRequest<int>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int IdCliente { get; set; }
        public int IdFreelancer { get; set; }
        public decimal CustoTotal { get; set; }
    }
}
