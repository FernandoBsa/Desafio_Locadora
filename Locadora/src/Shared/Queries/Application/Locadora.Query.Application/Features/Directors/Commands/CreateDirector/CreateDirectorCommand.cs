using MediatR;

namespace Locadora.Query.Application.Features.Directors.Commands.CreateDirector;

public record CreateDirectorCommand(string Id, string FullName, DateTime CreateAt, DateTime UpdatedAt) : IRequest<bool>;