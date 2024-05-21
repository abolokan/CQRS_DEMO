using Application.Abstractions.Messaging;
using Domain.Users;
using Shared;

namespace Application.Requests.Followers.StartFollowing;

internal sealed class StartFollowingCommandHandler : ICommandHandler<StartFollowingCommand>
{
    private readonly IUserRepository _userRepository;

    public StartFollowingCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(StartFollowingCommand command, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByIdAsync(command.userId, cancellationToken);
        if (user is null)
        {
            return UserErrors.NotFound(command.userId);
        }

        User? followed = await _userRepository.GetByIdAsync(command.FollowUserId, cancellationToken);
        if (followed is null)
        {
            return UserErrors.NotFound(command.FollowUserId);
        }

        return Result.Success();
    }
}
