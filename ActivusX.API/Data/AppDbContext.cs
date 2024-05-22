using ActivusX.API.Models.MSAD;
using Microsoft.EntityFrameworkCore;

namespace ActivusX.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ActiveDirectoryUser> ActiveDirectoryUsers { get; set; }
}

