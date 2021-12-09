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
            modelBuilder.Entity<Project>().HasKey(p=>p.Id);
            modelBuilder.Entity<Project>().HasOne(p=>p.Client).WithMany(user=> user.OwnedProjects)
                                            .HasForeignKey(p=> p.IdClient).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>().HasOne(p=>p.Freelancer).WithMany(user=>user.FreelancerProjects)
                                            .HasForeignKey(p=>p.IdFreelancer).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ProjectComment>().HasKey(pc=>pc.Id);
            modelBuilder.Entity<ProjectComment>().HasOne(pc=>pc.Project).WithMany(project=>project.Comments)
                                                    .HasForeignKey(pc => pc.IdProject).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProjectComment>().HasOne(pc=>pc.User).WithMany(user=>user.Comments)
                                                    .HasForeignKey(pc=>pc.IdUser).OnDelete(DeleteBehavior.Restrict);
        
        
            modelBuilder.Entity<User>().HasKey(u=>u.Id);
            modelBuilder.Entity<User>().HasMany(u=>u.Skills).WithOne();

            modelBuilder.Entity<UserSkill>().HasKey(us=> us.Id);
            
            modelBuilder.Entity<Skill>().HasKey(s=>s.Id);
            modelBuilder.Entity<Skill>().HasMany(s=>s.Users).WithOne();
        }

    }
}
