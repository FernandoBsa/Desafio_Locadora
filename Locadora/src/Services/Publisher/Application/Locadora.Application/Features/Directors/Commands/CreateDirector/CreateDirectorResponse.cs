namespace Locadora.Application.Features.Directors.Commands.CreateDirector;

public record CreateDirectorResponse(string Id, string FullName, DateTime CreatedAt, DateTime UpdateAt);