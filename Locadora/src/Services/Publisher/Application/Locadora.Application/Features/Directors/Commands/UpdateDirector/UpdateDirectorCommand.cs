using MediatR;

namespace Locadora.Application.Features.Directors.Commands.UpdateDirector;

public record UpdateDirectorCommand(Guid Id, string Name, string Surname) : IRequest<UpdateDirectorResponse>;
