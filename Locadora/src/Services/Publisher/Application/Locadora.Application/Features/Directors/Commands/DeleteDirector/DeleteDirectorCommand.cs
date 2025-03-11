using MediatR;

namespace Locadora.Application.Features.Directors.Commands.DeleteDirector;

public record DeleteDirectorCommand(Guid Id) : IRequest<bool>;