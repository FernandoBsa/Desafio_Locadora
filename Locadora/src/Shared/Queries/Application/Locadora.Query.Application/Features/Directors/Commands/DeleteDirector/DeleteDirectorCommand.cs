using MediatR;

namespace Locadora.Query.Application.Features.Directors.Commands.DeleteDirector;

public record DeleteDirectorCommand(string Id) : IRequest<bool>;