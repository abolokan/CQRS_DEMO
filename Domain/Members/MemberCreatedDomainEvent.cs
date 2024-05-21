using Shared;

namespace Domain.Members;

public sealed record MemberCreatedDomainEvent(Guid Id) : IDomainEvent;
