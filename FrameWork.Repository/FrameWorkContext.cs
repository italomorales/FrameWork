using FrameWork.Model;
using FrameWork.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FrameWork.Repository
{

    public class FrameWorkContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public FrameWorkContext(DbContextOptions<FrameWorkContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }

}
