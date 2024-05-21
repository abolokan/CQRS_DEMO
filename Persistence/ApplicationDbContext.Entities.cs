using Application.Abstractions.Data;
using Domain.Members;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public partial class ApplicationDbContext : IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Member> Members { get; set; }
}
