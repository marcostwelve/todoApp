using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
