using MediatR;

namespace DevFreela.Aplicacao.Commands.InserirComentario
{
    public class InserirComentarioCommand : IRequest<Unit>
    {
        public string Conteudo { get; set; }
        public int IdProjeto { get; set; }
        public int IdUsuario { get; set; }
    }
}
