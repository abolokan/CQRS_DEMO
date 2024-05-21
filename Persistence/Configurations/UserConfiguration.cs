using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Solid.Persistence.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(150);
        builder.Property(x => x.Name).HasConversion(
            value => value.Value,
            value => Name.Create(value).Value);

        builder.Property(x => x.Email).HasMaxLength(128);
        builder.Property(x => x.Email).HasConversion(
            value => value.Value,
            value => Email.Create(value).Value);
        builder.HasIndex(x => x.Email).IsUnique();
    }
}
