using MediatR;

namespace DevFreela.Aplicacao.Commands.AtualizarProjeto
{
    public class AtualizarProjetoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int IdCliente { get; set; }
        public decimal CustoTotal { get; set; }
    }
}
