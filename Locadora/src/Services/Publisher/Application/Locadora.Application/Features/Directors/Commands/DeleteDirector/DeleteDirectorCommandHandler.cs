using Locadora.Application.Contracts;
using Locadora.Application.Features.Directors.Commands.CreateDirector;
using MediatR;

namespace Locadora.Application.Features.Directors.Commands.DeleteDirector;

public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand, bool>
{
    private readonly IDirectorsWriteRepository _repository;

    public DeleteDirectorCommandHandler(IDirectorsWriteRepository repository)
    {
        _repository = repository;
    }


    public async Task<bool> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            return false;

        var director = await _repository.GetDirectorWithMovies(request.Id);

        if (director == null || director.Dvds.Any(x => x.Available))
            return false;

        return await _repository.Delete(director.Id);
    }
}