using MediatR;

namespace DevFreela.Aplicacao.Commands.FinalizarProjeto
{
    public class FinalizarProjetoCommand : IRequest<Unit>
    {
        public FinalizarProjetoCommand(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
