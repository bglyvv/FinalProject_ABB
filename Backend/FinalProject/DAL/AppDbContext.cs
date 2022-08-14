using Microsoft.EntityFrameworkCore;
using FinalProject.DAL.Entities;

namespace FinalProject.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }

}
