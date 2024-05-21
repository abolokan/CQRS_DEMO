using Domain.Users;

namespace Persistence.Repositories;

public class UserRepository : IUserRepository
{
    public Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Insert(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
