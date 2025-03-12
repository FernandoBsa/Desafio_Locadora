using MediatR;

namespace Locadora.Application.Features.Dvds.Commands.ReturnDvd;

public record ReturnDvdCommand(Guid Id) : IRequest<ReturnDvdResponse>;