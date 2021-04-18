using MediatR;

namespace DevFreela.Aplicacao.Commands.RemoverProjeto
{
    public class DeletarProjetoCommand : IRequest<Unit>
    {
        public DeletarProjetoCommand(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
