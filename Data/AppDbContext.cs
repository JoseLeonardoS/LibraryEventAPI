using LibraryEventAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryEventAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserModel> Users { get; set; }
    }
}
