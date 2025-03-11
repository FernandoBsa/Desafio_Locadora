using MediatR;

namespace Locadora.Application.Features.Directors.Commands.CreateDirector;

public record CreateDirectorCommand(string Name, string Surname) : IRequest<CreateDirectorResponse>;