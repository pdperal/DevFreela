using DevFreela.Aplicacao.Commands.Inserir;
using FluentValidation;

namespace DevFreela.Aplicacao.Validators
{
    public class InserirProjetoCommandValidator : AbstractValidator<InserirProjetoCommand>
    {
        public InserirProjetoCommandValidator()
        {
            RuleFor(p => p.Descricao)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo da Descrição é 255 caracteres.");

            RuleFor(p => p.Titulo)
                .MaximumLength(30)
                .WithMessage("Tamanho máximo do Titulo é de 30 caracteres");
        }
    }
}
