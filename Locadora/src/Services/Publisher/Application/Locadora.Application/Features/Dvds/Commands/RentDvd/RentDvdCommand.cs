using MediatR;

namespace Locadora.Application.Features.Dvds.Commands.RentDvd;

public record RentDvdCommand(Guid Id) : IRequest<RentDvdResponse>;