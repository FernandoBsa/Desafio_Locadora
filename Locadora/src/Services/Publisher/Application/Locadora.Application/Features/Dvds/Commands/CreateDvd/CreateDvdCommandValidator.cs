﻿using FluentValidation;
using Locadora.Core.ValidationMenssages;
using Locadora.Domain.Entities;

namespace Locadora.Application.Features.Dvds.Commands.CreateDvd;

public class CreateDvdCommandValidator : AbstractValidator<CreateDvdCommand>
{
    private const string GENRE_ERROR_MESSAGE = "Invalid genre type";
    private const int GENRE_ERROR_NUMBER = 19;
    private const int COPIES_ERROR_NUMBER = -1;

    public CreateDvdCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ValidationMessages.EMPTY_STRING_ERROR_MESSAGE)
            .MinimumLength(Dvd.MIN_TITLE_LENGTH).WithMessage(ValidationMessages.MIN_LENGTH_ERROR_MESSAGE)
            .MaximumLength(Dvd.MAX_TITLE_LENGTH).WithMessage(ValidationMessages.MAX_LENGTH_ERROR_MESSAGE);

        RuleFor(x => x.Genre)
            .LessThan(GENRE_ERROR_NUMBER).WithMessage(GENRE_ERROR_MESSAGE)
            .GreaterThan(COPIES_ERROR_NUMBER).WithMessage(GENRE_ERROR_MESSAGE);

        RuleFor(x => x.Published)
            .LessThan(DateTime.UtcNow).WithMessage(ValidationMessages.ERROR_MESSAGE);

        RuleFor(x => x.Copies)
            .GreaterThan(COPIES_ERROR_NUMBER).WithMessage(ValidationMessages.ERROR_MESSAGE);

        RuleFor(x => x.DirectorId)
            .NotEqual(Guid.Empty).WithMessage(ValidationMessages.ERROR_MESSAGE);
    }
}