using Locadora.Query.Application.Contracts;
using Locadora.Query.Domain.Models;
using MediatR;

namespace Locadora.Query.Application.Features.Directors.Commands.CreateDirector;

public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, bool>
{
    private readonly IDirectorsQueryRepository _repository;
    private readonly CreateDirectorCommandValidator _validator;

    public CreateDirectorCommandHandler(IDirectorsQueryRepository repository, CreateDirectorCommandValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<bool> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
            return false;

        var director = await _repository.Get(request.Id);
        if (director != null) 
            return false;

        director = new Director
        {
            Id = request.Id,
            FullName = request.FullName,
            CreatedAt = request.CreateAt,
            UpdateAt = request.UpdatedAt
        };
        
        var result = await _repository.Create(director);
        if (result == null)
            return false;
        
        return true;
    }
}