using Microsoft.EntityFrameworkCore;
using Project.Api.DAL.Entities;

namespace Project.Api.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }

}
