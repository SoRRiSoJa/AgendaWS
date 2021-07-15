using FluentValidation;

namespace AgendaWS.Validators
{
    using AgendaWS.Domain.Models;
    public class AgendaValidator : AbstractValidator<Agenda>
    {
        public AgendaValidator()
        {
            RuleFor((agenda) => agenda.Nome).NotNull().NotEmpty().WithMessage("Você deve informar um nome.");
            RuleFor((agenda) => agenda.Nome).MaximumLength(75).WithMessage("O nome deve ter até 75 caracteres.");
            RuleFor((agenda) => agenda.Numero).MaximumLength(25).WithMessage("O Numero do telefone deve ter até 25 caracteres.");
            RuleFor((agenda) => agenda.Ref).GreaterThanOrEqualTo(0).WithMessage("A ref deve ser maio ou igual a 0.");
        }
    }
}
