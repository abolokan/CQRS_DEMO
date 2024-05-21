using Shared;

namespace Domain.Users;

public sealed record UserCreatedDomainEvent(Guid Id) : IDomainEvent;