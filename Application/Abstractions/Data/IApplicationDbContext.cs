using Domain.Members;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Member> Members { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
