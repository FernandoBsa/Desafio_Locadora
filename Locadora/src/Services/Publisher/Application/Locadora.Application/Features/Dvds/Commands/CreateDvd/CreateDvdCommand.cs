﻿using MediatR;

namespace Locadora.Application.Features.Dvds.Commands.CreateDvd;

public record CreateDvdCommand(string Title, int Genre, DateTime Published, int Copies, Guid DirectorId) : IRequest<CreateDvdResponse>;