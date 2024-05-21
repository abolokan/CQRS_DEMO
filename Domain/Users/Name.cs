using Shared;

namespace Domain.Users;

public sealed record Name
{
    private Name(string value) => Value = value;

    public string Value { get; }

    public static Result<Name> Create(string? name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return Result.Failure<Name>(EmailErrors.Empty);
        }

        if (name.Split('@').Length != 2)
        {
            return Result.Failure<Name>(EmailErrors.InvalidFormat);
        }

        return new Name(name);
    }
}

