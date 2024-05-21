using Application.Abstractions.Data;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Persistence;

public partial class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AuditData();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void AuditData()
    {
        var trackedEntityStates = new[] { EntityState.Added, EntityState.Modified, EntityState.Deleted };

        var entries = ChangeTracker.Entries<Entity>().Where(x => trackedEntityStates.Contains(x.State));

        //.foreach (var entry in entries)
        //{
        //    entry.Entity.UpdatedDate = timestamp;
        //    entry.Entity.UpdatedUserId = sessionUserId;

        //    if (entry.State == EntityState.Added)
        //    {
        //        entry.Entity.CreatedDate = timestamp;
        //        entry.Entity.CreatedUserId = sessionUserId;
        //    }
        //    else if (entry.State == EntityState.Deleted && entry.Entity is IDeletedEntity)
        //    {
        //        (entry.Entity as IDeletedEntity).IsDeleted = true;
        //        entry.State = EntityState.Modified;
        //    }
        //    else
        //    {
        //        entry.Property(x => x.CreatedDate).IsModified = false;
        //        entry.Property(x => x.CreatedUserId).IsModified = false;
        //    }
        //}
    }
}
