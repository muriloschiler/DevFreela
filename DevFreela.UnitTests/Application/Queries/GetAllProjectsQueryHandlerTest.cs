using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DevFreela.Application.Queries.GetProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsQueryHandlerTest
    {
        [Fact]
        public async void ThreeProjectsExists_Executed_ReturnThreeProjectViewModel()
        {
            //Arrange
            var projects = new List<Project>
            { 
                new Project("Titulo1","Descricao1",1,1,1000),
                new Project("Titulo2","Descricao2",2,2,2000),
                new Project("Titulo3","Descricao3",3,3,3000),
            };
            
            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllProjects("").Result).Returns(projects);

            var getAllProjectQuery = new GetAllProjectQuery("");
            var getAllProjectQueryHandler = new GetAllProjectQueryHandler(projectRepositoryMock.Object);
            
            //Act
            var result = await getAllProjectQueryHandler.Handle(getAllProjectQuery,new CancellationToken());
            //Assert

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(projects.Count,result.Count);

            projectRepositoryMock.Verify(pr=>pr.GetAllProjects(""),Times.Once);
        }
    }
}