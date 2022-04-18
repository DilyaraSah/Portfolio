using Microsoft.EntityFrameworkCore;
using Portfolio.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Portfolio.DataAccess;

public class ApplicationContext: IdentityDbContext<User>
{
    //public DbSet<Request> Request { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}