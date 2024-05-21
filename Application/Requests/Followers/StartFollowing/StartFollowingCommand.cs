using Application.Abstractions.Messaging;

namespace Application.Requests.Followers.StartFollowing;

public sealed record StartFollowingCommand(Guid userId, Guid FollowUserId) : ICommand;