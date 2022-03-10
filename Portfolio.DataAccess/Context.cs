using Microsoft.EntityFrameworkCore;
using Portfolio.Entity;

namespace Portfolio.DataAccess;

public class Context: DbContext
{
    public DbSet<Request> Requests { get; set; } = null!;

    public Context(DbContextOptions options)
        :base(options) { }
}