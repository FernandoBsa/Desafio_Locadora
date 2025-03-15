using FluentValidation;
using Locadora.Core.ValidationConstants;
using Locadora.Core.ValidationMenssages;
using Locadora.Domain.Entities;

namespace Locadora.Application.Features.Dvds.Commands.CreateDvd;

public class CreateDvdCommandValidator : AbstractValidator<CreateDvdCommand>
{
    public CreateDvdCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ValidationMessages.EMPTY_STRING_ERROR_MESSAGE)
            .MinimumLength(Dvd.MIN_TITLE_LENGTH).WithMessage(ValidationMessages.MIN_LENGTH_ERROR_MESSAGE)
            .MaximumLength(Dvd.MAX_TITLE_LENGTH).WithMessage(ValidationMessages.MAX_LENGTH_ERROR_MESSAGE);

        RuleFor(x => x.Genre)
            .LessThan(ValidationConstants.GENRE_ERROR_NUMBER).WithMessage(ValidationConstants.GENRE_ERROR_MESSAGE)
            .GreaterThan(ValidationConstants.COPIES_ERROR_NUMBER).WithMessage(ValidationConstants.GENRE_ERROR_MESSAGE);

        RuleFor(x => x.Published)
            .LessThan(DateTime.UtcNow).WithMessage(ValidationMessages.ERROR_MESSAGE);

        RuleFor(x => x.Copies)
            .GreaterThan(ValidationConstants.COPIES_ERROR_NUMBER).WithMessage(ValidationMessages.ERROR_MESSAGE);

        RuleFor(x => x.DirectorId)
            .NotEqual(Guid.Empty).WithMessage(ValidationMessages.ERROR_MESSAGE);
    }
}