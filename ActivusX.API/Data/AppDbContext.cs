using ActivusX.Shared.Models.MSAD;
using ActivusX.Shared.Models.System;
using Microsoft.EntityFrameworkCore;

namespace ActivusX.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // SYSTEM
    public DbSet<AXUserAccount> AXUserAccounts { get; set; }
    public DbSet<AXUserTransaction> AXUserTransactions { get; set; }

    // ACTIVE DIRECTORY
    public DbSet<ActiveDirectoryUser> ActiveDirectoryUsers { get; set; }

    // INIT
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // seed a default sudo user
        var defaultRoleId = 1;
        modelBuilder.Entity<AXUserAccount>().HasData(
            new AXUserAccount
            {
                Id = defaultRoleId,
                EmailAddress = "admin@activusx.pro",
                Password = "xxxxxxx",
                userAccountRole = Shared.Models.System.Enums.AXUserAccountRole.sudo,
                userAccountStatus = Shared.Models.System.Enums.AXUserAccountStatus.Enabled,
                userAccountCreated = DateTime.UtcNow,
                EmailVerified = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            }
        );
    }
}

