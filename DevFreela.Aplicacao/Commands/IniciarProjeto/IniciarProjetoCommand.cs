using MediatR;

namespace DevFreela.Aplicacao.Commands.IniciarProjeto
{
    public class IniciarProjetoCommand : IRequest<Unit>
    {
        public IniciarProjetoCommand(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
