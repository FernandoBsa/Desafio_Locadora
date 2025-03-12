using MediatR;

namespace Locadora.Application.Features.Dvds.Commands.DeleteDvd;

public record DeleteDvdCommand(Guid Id) : IRequest<DeleteDvdResponse>;
