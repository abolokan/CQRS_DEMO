using Shared;

namespace Domain.Members;

public sealed class Member : Entity
{
    private Member(Guid id, string email, string firstName, string lastName)
        : base(id)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    private Member() { }

    public string Email { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public static Member Create(string email, string firstName, string lastName)
    {
        var member = new Member(Guid.NewGuid(), email, firstName, lastName);

        member.Raise(new MemberCreatedDomainEvent(member.Id));

        return member;
    }
}
