using System.Data.Entity;
using TryingDbContext.Models;

namespace TryingDbContext;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
}