using MediatR;

namespace Locadora.Query.Application.Features.Directors.Commands.UpdateDirector;

public record UpdateDirectorCommand(string Id, string FullName, DateTime UpdatedAt) : IRequest<bool>;