using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void ProjectStarts_Executed_ProjectStatusInprogress()
        {
            //Arrange
            Project project = new Project("Titulo","Descricao",1,5000);           
            //Act
            project.Start();
            //Act
            Assert.Equal(project.ProjectStatus,ProjectStatus.InProgress);
            Assert.NotNull(project.StartedAt);
        }
        
        [Fact]
        public void freelancerApllyProjectWhitoutCandidates_Executed_ListCandidateWithIdFreelancer()
        {
            //Arrange
            Project project = new Project("Titulo","Descricao",1,1000);
            //Act
            var result = project.Aplly(2);
            //Assert
            Assert.Equal(2,project.ListCandidates[1]);
            Assert.Equal(true,result);
        }

        [Fact]
        public void freelancerApllyProjectAgain_Executed_False()
        {
            //Arrange
            Project project = new Project("Titulo","Descricao",1,1000);
            //Act
            project.Aplly(2);
            var result = project.Aplly(2);
            //Assert
            Assert.Equal(false,result);
        }

    }
}