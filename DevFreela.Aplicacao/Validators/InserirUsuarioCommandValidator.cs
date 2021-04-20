using DevFreela.Aplicacao.Commands.InserirUsuario;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevFreela.Aplicacao.Validators
{
    public class InserirUsuarioCommandValidator : AbstractValidator<InserirUsuarioCommand>
    {
        public InserirUsuarioCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("Email não valido!.");

            RuleFor(p => p.Senha)
                .Must(SenhaValida)
                .WithMessage("Senha deve ter pelo menos 8 caracteres, um número, uma letra maiúscula, uma letra minúscula e um caractere especial.");

            RuleFor(p => p.NomeCompleto)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser preenchido!");
        }

        public static bool SenhaValida(string senha)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(senha);
        }
    }
}
