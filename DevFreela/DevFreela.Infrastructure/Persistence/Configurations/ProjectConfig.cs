using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p=>p.Id);
            
            builder.HasOne(p=>p.Client).WithMany(user=> user.OwnedProjects)
                                            .HasForeignKey(p=> p.IdClient).OnDelete(DeleteBehavior.Restrict);
                                            
            builder.HasOne(p=>p.Freelancer).WithMany(user=>user.FreelancerProjects)
                                            .HasForeignKey(p=>p.IdFreelancer).OnDelete(DeleteBehavior.Restrict);
        }
    }
}