using Microsoft.EntityFrameworkCore;
using Portfolio.Entity;

namespace Portfolio.DataAccess;

public class ApplicationContext: DbContext
{
    public DbSet<Request> Request { get; set; } = null!;
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        :base(options) { }
}