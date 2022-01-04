using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void ProjectStarts_Executed_ProjectStatusInprogress(){
            Project project = new Project("Titulo","Descricao",1,1,5000);           

            project.Start();
            Assert.Equal(project.ProjectStatus,ProjectStatus.InProgress);
            Assert.NotNull(project.StartedAt);
        }
        
    }
}