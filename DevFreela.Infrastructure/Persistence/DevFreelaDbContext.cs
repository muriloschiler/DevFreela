using System.Reflection;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options):base(options) {}

        
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<User>().HasKey(u=>u.Id);
            modelBuilder.Entity<User>().HasMany(u=>u.Skills).WithOne();

            modelBuilder.Entity<UserSkill>().HasKey(us=> us.Id);
            
            modelBuilder.Entity<Skill>().HasKey(s=>s.Id);
            modelBuilder.Entity<Skill>().HasMany(s=>s.Users).WithOne();
        }

    }
}
