using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async void ZeroProjectsExists_Executed_OneProjectCreated(){
            //Arrange
            var listProjects = new List<Project>();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock
                .Setup(pr=>pr.AddProject(It.IsAny<Project>()))
                .Callback<Project>(p=> listProjects.Add(p));
            
            var createProjectCommand = new CreateProjectCommand("TituloTeste","Descricao1",1,1,1000);

            var createProjectCommandHandler =new CreateProjectCommandHandler(projectRepositoryMock.Object);
            //Act
            await createProjectCommandHandler.Handle(createProjectCommand,new CancellationToken());
            //Assert
            Assert.NotEmpty(listProjects);
            Assert.Equal(
                
                new List<string>
                {
                    createProjectCommand.Title,
                    createProjectCommand.Description,
                    createProjectCommand.IdClient.ToString(),
                    createProjectCommand.IdFreelancer.ToString(),
                    createProjectCommand.TotalCost.ToString(),
                },
                new List<string>
                {
                    listProjects[0].Title,
                    listProjects[0].Description,
                    listProjects[0].IdClient.ToString(),
                    listProjects[0].IdFreelancer.ToString(),
                    listProjects[0].TotalCost.ToString(),
                } 
            );

        }
    }
}